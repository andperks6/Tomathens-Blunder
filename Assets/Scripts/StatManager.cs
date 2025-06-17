using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{

	public string race;
	public bool upStats;
	private int primayAtrib;
	public int playerlvl;
	public CharacterController player;
	public Textmenu text1;
	public InterfaceMain Inventory;
	public hudspells hudspells2;
	public GameObject playerHealthbar;
	public GameObject playerManabar;
	public GameObject playerXPbar;
	public GameObject playerSpellslots;
	public float healthPercent;
	public float gold;
	public float garnet;
	public float ruby;
	public float strength;
	public float wisdom;
	public float speed;
	public float health;
	public float movespeed;
	public float damage;
	public float magicka;
	public float magickaCurrent;
	public float magickaPercent;
	public float magickaRegen;
	public float healthRegen;
	public float sprintregen;
	public float haste;
	public float strength1;
	public float wisdom1;
	public float speed1;
	public float health1;
	public float movespeed1;
	public float damage1;
	public float magicka1;
	public float magickaRegen1;
	public float healthRegen1;
	public float haste1;
	public float sprintregen1;
	public float firelevel;
	public float waterlevel;
	public float earthlevel;
	public float airlevel;
	public float lightlevel;
	public float darklevel;
	public float sorcerylevel;
	public float enchantmentlevel;
	public float rituallevel;
	public bool fountian;
	private Vector2 fp;
	private Vector2 position;
	public float distance;
	public int itemID;
	public int KeyID;
	public bool redKey;
	public bool blueKey;
	public bool yellowKey;
	public bool greenKey;
	public bool tealKey;
	public bool purpleKey;
	public bool biegeKey;
	public bool LavenderKey;
	public int box1spell;
	public int box2spell;
	public int box3spell;
	public int box4spell;
	public int box5spell;
	public int box6spell;

	public float xp;




	// Use this for initialization
	void Start()
	{
		firelevel = 1;
		waterlevel = 1;
		earthlevel = 1;
		airlevel = 1;
		darklevel = 1;
		lightlevel = 1;
		sorcerylevel = 1;
		rituallevel = 1;
		enchantmentlevel = 1;
		// Primary Atribute  1 = strength, 2 = wisdom, 3 = speed

		player = GetComponent<CharacterController>();
		text1 = GetComponentInChildren<Textmenu>();
		GameObject healthbar = (GameObject)Instantiate(playerHealthbar, new Vector2(transform.position.x + 4, transform.position.y - 6.2f), Quaternion.Euler(0, 0, 0));
		healthbar.transform.parent = transform;
		PlayerBars pbh = healthbar.GetComponent<PlayerBars>();
		pbh.sm = gameObject.GetComponent<StatManager>();
		GameObject manabar = (GameObject)Instantiate(playerManabar, new Vector2(transform.position.x + 4, transform.position.y - 6.7f), Quaternion.Euler(0, 0, 0));
		manabar.transform.parent = transform;
		PlayerBars pbh2 = manabar.GetComponent<PlayerBars>();
		pbh2.sm = gameObject.GetComponent<StatManager>();
		GameObject xpbar = (GameObject)Instantiate(playerXPbar, new Vector2(transform.position.x - 5, transform.position.y - 5.8f), Quaternion.Euler(0, 0, 0));
		xpbar.transform.parent = transform;
		PlayerBars pbh3 = xpbar.GetComponent<PlayerBars>();
		pbh3.sm = gameObject.GetComponent<StatManager>();
		GameObject spellslots = (GameObject)Instantiate(playerSpellslots, new Vector2(transform.position.x - 5, transform.position.y - 6.5f), Quaternion.Euler(0, 0, 0));
		spellslots.transform.parent = transform;
		hudspells hudspells = spellslots.GetComponent<hudspells>();
		hudspells.sm = gameObject.GetComponent<StatManager>();
		hudspells2 = hudspells.GetComponent<hudspells>();


		gold = 25;
		if (player != null)
		{
			race = player.race;
		}

		if (race == "Toad")
		{
			primayAtrib = 1;
			waterlevel = 5;
		}
		if (race == "Stoat")
		{
			primayAtrib = 1;
			earthlevel = 5;
		}
		if (race == "Rat")
		{
			primayAtrib = 2;
			darklevel = 5;
		}
		if (race == "Moth")
		{
			primayAtrib = 2;
			airlevel = 5;
		}
		if (race == "Mouse")
		{
			primayAtrib = 3;
			lightlevel = 5;
		}
		if (race == "Newt")
		{
			primayAtrib = 3;
			firelevel = 5;
		}

		playerlvl = 1;
		if (primayAtrib == 1)
		{
			strength = 3;
			wisdom = 1;
			speed = 1;
		}
		if (primayAtrib == 2)
		{
			strength = 1;
			wisdom = 3;
			speed = 1;
		}
		if (primayAtrib == 3)
		{
			strength = 1;
			wisdom = 1;
			speed = 3;
		}
		health1 = 100;
		movespeed1 = 4.8f;
		damage1 = 30;
		magicka1 = 50;
		magickaRegen1 = 1;
		healthRegen1 = 0;
		haste1 = 0;
		sprintregen1 = 1;
		updateStat();

		magickaCurrent = 55;
	}

	// Update is called once per frame
	void Update()
	{

		//text1 = GetComponentInChildren<Textmenu>();
		position = new Vector2(transform.position.x, transform.position.y);


		if (fountian == true)
		{
			distance = Vector2.Distance(position, fp);
			if (Vector2.Distance(position, fp) < 6)

			{
				if (magicka > magickaCurrent)
				{
					magickaCurrent = magickaCurrent + 5 * Time.deltaTime;
				}
			}
			else
			{
				fountian = false;

			}
		}
		if (Input.GetKeyDown("tab"))
		{
			updateStat();

		}
		if (magickaCurrent < magicka)
		{
			magickaCurrent = magickaCurrent + magickaRegen * Time.deltaTime;
		}




		float mid = magicka / magickaCurrent;
		magickaPercent = 100 / mid;




	}
	public void updateStat()
	{
		health = health1 + strength * 10;
		movespeed = movespeed1 + speed * .2f;
		damage = damage1 + strength;
		magicka = magicka1 + wisdom * 5;
		magickaRegen = magickaRegen1 + wisdom * .5f;
		healthRegen = healthRegen1 + strength * .25f;
		haste = haste1 + speed * .015f;
		sprintregen = sprintregen1 + speed * .5f;
		text1.garnetAmount = garnet;
		text1.rubyAmount = ruby;
		text1.goldAmount = gold;
		text1.damageAmount = damage;
		text1.healthAmount = health;
		text1.StrengthAmount = strength;
		text1.wisdomAmount = wisdom;
		text1.speedAmount = speed;
		text1.movementAmount = movespeed;
		text1.magickaAmount = magicka;
		text1.magickaregenAmount = magickaRegen;
		text1.healthregenAmount = healthRegen;
		text1.hasteAmount = haste;
		text1.sprintregenAmount = sprintregen;



	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Fountian")
		{
			fountian = true;
			fp = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y);

		}

	}
	public void itemBought(int coin, int item, bool spell)
	{
		gold = gold - coin;
		itemID = item;

		addItem(spell);



	}
	public void KeyBought(int coin, int item)
	{
		gold = gold - coin;
		KeyID = item;
		addKey();

	}
	public void levelup()
	{
		if (race == "Toad")
		{
			strength = strength + 2;
			wisdom++;
			speed++;
			waterlevel++;
		}
		if (race == "Stoat")
		{
			strength = strength + 2;
			wisdom++;
			speed++;
			earthlevel++;

		}
		if (race == "Rat")
		{
			wisdom = wisdom + 2;
			strength++;
			speed++;
			darklevel++;
		}
		if (race == "Moth")
		{
			wisdom = wisdom + 2;
			strength++;
			speed++;
			airlevel++;

		}
		if (race == "Mouse")
		{
			speed = speed + 2;
			wisdom++;
			strength++;
			lightlevel++;
		}
		if (race == "Newt")
		{
			speed = speed + 2;
			wisdom++;
			strength++;
			firelevel++;
		}



	}

	private void addItem(bool spell)
	{
		Inventory = player.ifm;
		Inventory.GetComponent<InterfaceMain>().NewItem(itemID, spell);
	}

	private void addKey()
	{
		Inventory = player.ifm;
		Inventory.GetComponent<InterfaceMain>().NewKey(KeyID);
		if (KeyID == 1)
		{ redKey = true; }
		if (KeyID == 2)
		{ yellowKey = true; }
		if (KeyID == 3)
		{ greenKey = true; }
		if (KeyID == 4)
		{ blueKey = true; }
		if (KeyID == 5)
		{ tealKey = true; }
		if (KeyID == 6)
		{ purpleKey = true; }
		if (KeyID == 7)
		{ biegeKey = true; }
		if (KeyID == 8)
		{ LavenderKey = true; }
	}

}
