using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyBehaviour : MonoBehaviour
{
	private float despawnTimer = 90f; // 1:30 minute lifetime
	private Vector3 pos;
	public float movespeed;
	public float cricketdirection;
	public float directtimer;
	public float restTimer;
	public Animator anim;
	public SpriteRenderer sprite;
	public BoxCollider2D collison;
	public StatManager sm;
	private float x;
	private float y;
	public bool flip;
	private bool touched;
	public bool free;
	public bool aggresive;
	public bool attack;
	public bool directSet;
	public bool rest;
	public float stuckCounter;
	public float stuckFeedback;
	public float touchtimer;
	public string WP;
	private Vector2 playerDistance;
	public Vector2 followPos;
	private float animTime;
	public float attackTime;
	public BotHealth HealthBar;
	private float takingdamagetimer;
	public bool readytotakedamage;
	public bool Dead;
	public float damage;
	private float transperency;
	public string EnemyTag;
	public bool EnemySelect;
	public GameObject Box;
	public GameObject loot;
	private float changecolor;
	private bool clicked;
	public float xp;
	private bool xpgiven;





	// Use this for initialization
	void Start()
	{
		Dead = false;
		readytotakedamage = true;
		takingdamagetimer = .1f;
		attackTime = 1f;
		animTime = -1;
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
		collison = GetComponent<BoxCollider2D>();
		movespeed = 1f;
		directSet = true;
		directtimer = 10;
		restTimer = 4;
		rest = false;
		touchtimer = .3f;
		stuckFeedback = 0;
		cricketdirection = Random.Range(1, 4);
		stuckCounter = 6.5f;
		aggresive = false;
		transperency = 1;
		changecolor = .4f;


	}

	// Update is called once per frame
	void Update()
	{
		// Update despawn timer
		despawnTimer -= Time.deltaTime;
		
		// Start fading when 5 seconds remain
		if (despawnTimer <= 5f && !Dead)
		{
			float fadeAlpha = despawnTimer / 5f;
			sprite.color = new Color(1, 1, 1, fadeAlpha);
		}
		
		if (despawnTimer <= 0 && !Dead)
		{
			Dead = true;
			// Don't give XP when despawning
			xpgiven = true;
		}

		if (Dead == false)
		{

			if (readytotakedamage == false)
			{
				takingdamagetimer = takingdamagetimer - Time.deltaTime;
				if (takingdamagetimer < 0)
				{
					readytotakedamage = true;
				}
			}

			if (aggresive == true)
			{


				animTime = animTime - Time.deltaTime;
				followPos = GameObject.Find(WP).transform.position;

				rest = false;
				if (playerDistance.y < 0)
				{
					sprite.sortingOrder = 9;
				}
				else
				{
					sprite.sortingOrder = 11;
				}

				playerDistance = new Vector2(followPos.x - transform.position.x, followPos.y - transform.position.y);

				if (attack == true && attackTime > 0)
				{
					attackTime = attackTime - Time.deltaTime;
					movespeed = 0;
					anim.SetBool("Attack", attack);
					if (attackTime < 0)
					{
						attack = false;
						anim.SetBool("Attack", attack);
						movespeed = 1f;
						attackTime = 2f;
					}
				}
				if (attack == false)
				{


					if (animTime < 0)
					{
						if (playerDistance.x > 0 && Mathf.Abs(playerDistance.x) > Mathf.Abs(playerDistance.y))
						{
							cricketdirection = 1;
						}
						if (playerDistance.x < 0 && Mathf.Abs(playerDistance.x) > Mathf.Abs(playerDistance.y))
						{
							cricketdirection = 3;
						}
						if (playerDistance.y > 0 && Mathf.Abs(playerDistance.x) < Mathf.Abs(playerDistance.y))
						{
							cricketdirection = 4;
						}
						if (playerDistance.y < 0 && Mathf.Abs(playerDistance.x) < Mathf.Abs(playerDistance.y))
						{
							cricketdirection = 2;
						}

						animTime = .7f;


					}
					if (Mathf.Abs(playerDistance.x) + Mathf.Abs(playerDistance.y) - .6f < 1.2f && aggresive == true)
					{
						attack = true;


					}
					if (Mathf.Abs(playerDistance.x) + Mathf.Abs(playerDistance.y) > 15f)
					{
						aggresive = false;
					}


				}
			}

			if (stuckCounter < 7)
			{
				stuckCounter = stuckCounter - Time.deltaTime;
				if (stuckCounter < 0 && stuckFeedback > 2)
				{
					free = true;
					stuckFeedback = 0;
					stuckCounter = 6.5f;

				}
				if (stuckCounter < 0 && stuckFeedback <= 2)
				{

					stuckFeedback = 0;
					stuckCounter = 6.5f;

				}

			}



			if (directSet == false && rest == false && aggresive == false)
			{
				directtimer = directtimer - Time.deltaTime;
			}
			if (rest == true && aggresive == false)
			{
				restTimer = restTimer - Time.deltaTime;
				anim.SetBool("Stop", true);
				if (restTimer < 0)
				{
					rest = false;
					directtimer = Random.Range(7, 12);
					directSet = true;
					restTimer = Random.Range(2, 4);

				}
			}

			if (directSet == true && directtimer > 6 && rest == false && aggresive == false)
			{

				cricketdirection = Random.Range(1, 4);

			}


			if (cricketdirection == 1 && rest == false)
			{
				//right
				anim.SetBool("Stop", false);
				pos = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y, transform.position.z);
				transform.position = new Vector3(pos.x, pos.y, pos.z);
				directSet = false;

				x = 1;
				y = 0;
				if (flip == true)
				{
					aggresive = false;
					cricketdirection = 3;
					flip = false;
				}

				if (directtimer < 0)
				{

					rest = true;

				}
				if (free == true)
				{
					cricketdirection = 4;
					free = false;
				}

			}
			if (cricketdirection == 2 && rest == false)
			{
				//down
				anim.SetBool("Stop", false);
				pos = new Vector3(transform.position.x, transform.position.y - movespeed * Time.deltaTime, transform.position.z);
				transform.position = new Vector3(pos.x, pos.y, pos.z);
				directSet = false;
				x = 0;
				y = -1;
				if (flip == true)
				{
					aggresive = false;
					cricketdirection = 4;
					flip = false;
				}

				if (directtimer < 0)
				{

					rest = true;

				}
				if (free == true)
				{
					cricketdirection = 1;
					free = false;
				}



			}
			if (cricketdirection == 3 && rest == false)
			{
				//left
				anim.SetBool("Stop", false);
				pos = new Vector3(transform.position.x - movespeed * Time.deltaTime, transform.position.y, transform.position.z);
				transform.position = new Vector3(pos.x, pos.y, pos.z);
				directSet = false;
				x = -1;
				y = 0;
				if (flip == true)
				{
					aggresive = false;
					cricketdirection = 1;
					flip = false;
				}

				if (directtimer < 0)
				{
					rest = true;
				}
				if (free == true)
				{
					cricketdirection = 2;
					free = false;
				}


			}
			if (cricketdirection == 4 && rest == false)
			{
				//up
				anim.SetBool("Stop", false);
				pos = new Vector3(transform.position.x, transform.position.y + movespeed * Time.deltaTime, transform.position.z);
				transform.position = new Vector3(pos.x, pos.y, pos.z);
				directSet = false;
				x = 0;
				y = 1;
				if (flip == true)
				{
					aggresive = false;
					cricketdirection = 2;
					flip = false;
				}

				if (directtimer < 0)
				{

					rest = true;

				}
				if (free == true)
				{
					cricketdirection = 3;
					free = false;
				}

			}
			anim.SetFloat("X", x);
			anim.SetFloat("Y", y);
			if (touched == true)
			{


				touchtimer = touchtimer - Time.deltaTime;
				if (touchtimer < 0)
				{
					touched = false;
					touchtimer = .3f;

				}
			}

			if (changecolor > 0)
			{
				changecolor = changecolor - Time.deltaTime;
			}
			else
			{
				sprite.color = new Color(1, 1, 1, 1);
				changecolor = .4f;
			}

		}
		else
		{
			sprite.sortingOrder = 9;
			collison.enabled = false;
			anim.SetBool("Dead", true);
			sprite.color = new Color(1, 1, 1, transperency);
			transperency = transperency - .001f;
			if (xpgiven == false && sm != null)
			{
				sm.xp = sm.xp + xp;
				xpgiven = true;
			}
			if (transperency < 0)
			{
				Destroy(gameObject);
			}
		}
		if (EnemyTag == "DeadPlayer")
		{
			attack = false;
			aggresive = false;
			attack = false;
			anim.SetBool("Attack", attack);
			movespeed = 1f;
			attackTime = 2f;

		}

	}
	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.gameObject.tag == "collisionblocks" && touchtimer == .3f)
		{

			flip = true;
			touched = true;
			stuckFeedback++;
		}


	}
	public void HurtByPlayer(float damage, StatManager sm1)
	{
		if (readytotakedamage == true)
		{
			sprite.color = new Color(1, .5f, .5f, 1);
			HealthBar.healthCurrent -= damage;
			readytotakedamage = false;
			sm = sm1;
			if (HealthBar.healthCurrent <= 0)
			{
				Dead = true;
			}
		}
	}
	public void OnMouseOver()
	{
		if (Dead == true && clicked == false)
		{
			SelectBox select = Box.GetComponentInChildren<SelectBox>();
			select.show = true;

		}
	}
	public void OnMouseExit()
	{
		SelectBox select = Box.GetComponentInChildren<SelectBox>();
		select.show = false;
	}
	public void OnMouseDown()
	{
		if (Dead == true && clicked == false)
		{
			GameObject lootbox = (GameObject)Instantiate(loot, transform.position, Quaternion.Euler(0, 0, 0));
			lootbox.transform.parent = gameObject.transform;
			Loot stat = lootbox.GetComponent<Loot>();
			stat.sm = sm;
			clicked = true;

		}
	}
}
