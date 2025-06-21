using UnityEngine;

public class RangedEnemyBehaviour : MonoBehaviour {
    private float despawnTimer = 90f; // 1.5 min lifetime
    
    public GameObject Box;
    public GameObject projectile;
    public Transform psPoint;
    public BoxCollider2D collison;
    public StatManager stat;
    public int PointP;
    public Animator anim;
    public SpriteRenderer sprite;
    public Vector3 projectileS;
    public Vector2 playerDistance;
    public Vector2 followPos;
    public Vector2 stop;
    private Vector3 pos;
    public GameObject loot;
    public bool flip;
    private bool touched;
    public bool free;
    public bool aggresive;
    public bool attack;
    public bool directSet;
    public bool rest;
    public bool create;
    public bool Shoot;
    public float movespeed;
    public float cricketdirection;
    public float directtimer;
    public float restTimer;
    public float x;
    public float y;
    public float stuckCounter;
    public float stuckFeedback;
    public float touchtimer;
    public float attackTime;
    public float offset;
    private float animTime;
    public string WP;
    public BotHealth HealthBar;
    public bool dead;
    private float takingdamagetimer;
    public bool readytotakedamage;
    public float damage;   
    private float transperency;
    public float range;
    public float ProjSpawntime;
    private float ProjSpawntimeRE;
    public string EnemyTag;
    private float changecolor;
    public float xp;
    private bool xpgiven;
    private bool clicked;
    private static readonly int Stop = Animator.StringToHash("Stop");

    // Use this for initialization
    void Start()
    {
        dead = false;
        readytotakedamage = true;
        takingdamagetimer = .2f;
        attackTime = 1.5f;
        animTime = -1;
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collison = GetComponent<BoxCollider2D>();
        directSet = true;
        directtimer = 10;
        restTimer = 4;
        rest = false;
        touchtimer = .3f;
        stuckFeedback = 0;
        cricketdirection = Random.Range(1, 4);
        stuckCounter = 6.5f;
        aggresive = false;
        create = true;
        damage = 10;
        transperency = 1f;
        movespeed = 1.3f;
        ProjSpawntimeRE = ProjSpawntime;
        changecolor = .4f;

    }
    //psPoint.transform.position.x
    // Update is called once per frame
    void Update()
    {
        // Update despawn timer
        despawnTimer -= Time.deltaTime;
        
        // Start fading when 5 seconds remain
        if (despawnTimer <= 5f && !dead)
        {
            float fadeAlpha = despawnTimer / 5f;
            sprite.color = new Color(1, 1, 1, fadeAlpha);
        }
        
        if (despawnTimer <= 0 && !dead)
        {
            dead = true;
            // Don't give XP when despawning
            xpgiven = true;
        }

        if (dead == false)
        {
            if (readytotakedamage == false)
            {
                takingdamagetimer = takingdamagetimer - Time.deltaTime;
                if (takingdamagetimer < 0)
                {
                    readytotakedamage = true;
                }
            }
            if (aggresive)
            {


                animTime = animTime - Time.deltaTime;
                rest = false;
                followPos = GameObject.Find(WP).transform.position;
                EnemyTag = GameObject.Find(WP).tag;
                if (playerDistance.y < 0)
                {
                    sprite.sortingOrder = 9;
                }
                else
                {
                    sprite.sortingOrder = 11;
                }

                var position = transform.position;
                playerDistance = new Vector2(followPos.x - position.x, followPos.y - position.y);

                if (attack && attackTime > 0)
                {
                    Shoot = false;
                    attackTime = attackTime - Time.deltaTime;
                    movespeed = 0;

                    if (playerDistance.x > 0 && Mathf.Abs(playerDistance.x) > Mathf.Abs(playerDistance.y))
                    {
                        x = 1;
                        y = 0;
                        projectileS = new Vector3(followPos.x + range, followPos.y, transform.position.z);
                        PointP = 2;

                    }
                    if (playerDistance.x < 0 && Mathf.Abs(playerDistance.x) > Mathf.Abs(playerDistance.y))
                    {
                        x = -1;
                        y = 0;
                        projectileS = new Vector3(followPos.x - range, followPos.y - 1, transform.position.z);
                        PointP = 4;

                    }
                    if (playerDistance.y > 0 && Mathf.Abs(playerDistance.x) < Mathf.Abs(playerDistance.y))
                    {
                        x = 0;
                        y = 1;
                        projectileS = new Vector3(followPos.x, followPos.y + range, transform.position.z);
                        PointP = 3;

                    }
                    if (playerDistance.y < 0 && Mathf.Abs(playerDistance.x) < Mathf.Abs(playerDistance.y))
                    {
                        x = 0;
                        y = -1;
                        projectileS = new Vector3(followPos.x - .7f, followPos.y - range, transform.position.z);
                        PointP = 1;

                    }
                    anim.SetBool("Attack", attack);
                    anim.SetFloat("X", x);
                    anim.SetFloat("Y", y);
                    if (create)
                    {
                        ProjSpawntime = ProjSpawntime - Time.deltaTime;
                        if (x == 1)
                        {
                            offset = -.70f;
                        }


                        if (x == -1)
                        {
                            offset = -.2f;
                        }
                        if (y == 1 || y == -1)
                        {
                            offset = 0;
                        }
                        if (ProjSpawntime < 0.1)
                        {
                            Vector3 stp = new Vector3(psPoint.transform.position.x + offset, psPoint.transform.position.y, psPoint.transform.position.z);
                            GameObject fireball = Instantiate(projectile, stp, Quaternion.Euler(0, 0, 0));
                            fireball.transform.parent = gameObject.transform;
                            create = false;
                            Shoot = false;
                            ProjSpawntime = ProjSpawntimeRE;
                        }
                    }
                    if (attackTime < .5f)
                    {
                        Shoot = true;
                    }


                    if (attackTime < 0)
                    {

                        attack = false;
                        anim.SetBool("Attack", attack);
                        movespeed = 1.3f;
                        attackTime = 1.5f;
                        create = true;
                    }
                }
                if (attack == false)
                {

                    if (animTime < 0)
                    {

                        if (playerDistance.x > 0 && Mathf.Abs(playerDistance.x) < Mathf.Abs(playerDistance.y))
                        {
                            cricketdirection = 1;
                            stop.y = playerDistance.y;
                        }
                        if (playerDistance.x < 0 && Mathf.Abs(playerDistance.x) < Mathf.Abs(playerDistance.y))
                        {
                            cricketdirection = 3;
                            stop.y = -playerDistance.y;
                        }
                        if (playerDistance.y > 0 && Mathf.Abs(playerDistance.x) > Mathf.Abs(playerDistance.y))
                        {
                            cricketdirection = 4;
                            stop.x = playerDistance.x;
                        }
                        if (playerDistance.y < 0 && Mathf.Abs(playerDistance.x) > Mathf.Abs(playerDistance.y))
                        {
                            cricketdirection = 2;
                            stop.x = -playerDistance.x;
                        }

                        animTime = .7f;


                    }

                    if (Mathf.Abs(playerDistance.x) - stop.x + Mathf.Abs(playerDistance.y) - stop.y < 1f)
                    {
                        attack = true;

                    }

                    if (Mathf.Abs(playerDistance.x) + Mathf.Abs(playerDistance.y) > 15f)
                    {
                        aggresive = false;
                        attack = false;
                    }
                    stop = new Vector2(0, 0);
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
            if (rest && aggresive == false)
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

            if (directSet && directtimer > 6 && rest == false && aggresive == false)
            {

                cricketdirection = Random.Range(1, 4);

            }


            if (cricketdirection == 1 && rest == false && attack == false)
            {
                //right
                anim.SetBool("Stop", false);
                pos = new Vector3(transform.position.x + movespeed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.position = new Vector3(pos.x, pos.y, pos.z);
                directSet = false;

                x = 1;
                y = 0;
                if (flip)
                {
                    aggresive = false;
                    cricketdirection = 3;
                    flip = false;
                }

                if (directtimer < 0)
                {

                    rest = true;

                }
                if (free)
                {
                    cricketdirection = 4;
                    free = false;
                }

            }
            if (cricketdirection == 2 && rest == false && attack == false)
            {
                //down
                anim.SetBool("Stop", false);
                var transform1 = transform;
                var position = transform1.position;
                pos = new Vector3(position.x, position.y - movespeed * Time.deltaTime, position.z);
                position = new Vector3(pos.x, pos.y, pos.z);
                transform1.position = position;
                directSet = false;
                x = 0;
                y = -1;

                if (flip)
                {
                    aggresive = false;
                    cricketdirection = 4;
                    flip = false;
                }

                if (directtimer < 0)
                {

                    rest = true;

                }
                if (free)
                {
                    cricketdirection = 1;
                    free = false;
                }



            }
            if (cricketdirection == 3 && rest == false && attack == false)
            {
                //left
                anim.SetBool(Stop, false);
                var transform1 = transform;
                var position = transform1.position;
                pos = new Vector3(position.x - movespeed * Time.deltaTime, position.y, position.z);
                position = new Vector3(pos.x, pos.y, pos.z);
                transform1.position = position;
                directSet = false;
                x = -1;
                y = 0;

                if (flip)
                {
                    aggresive = false;
                    cricketdirection = 1;
                    flip = false;
                }

                if (directtimer < 0)
                {
                    rest = true;
                }
                if (free)
                {
                    cricketdirection = 2;
                    free = false;
                }


            }
            if (cricketdirection == 4 && rest == false && attack == false)
            {
                //up
                anim.SetBool("Stop", false);
                pos = new Vector3(transform.position.x, transform.position.y + movespeed * Time.deltaTime, transform.position.z);
                transform.position = new Vector3(pos.x, pos.y, pos.z);
                directSet = false;
                x = 0;
                y = 1;

                if (flip)
                {
                    aggresive = false;
                    cricketdirection = 2;
                    flip = false;
                }

                if (directtimer < 0)
                {

                    rest = true;

                }
                if (free)
                {
                    cricketdirection = 3;
                    free = false;
                }

            }


            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);

            if (touched)
            {
                touchtimer = touchtimer - Time.deltaTime;
                if (touchtimer < 0)
                {
                    touched = false;
                    touchtimer = .3f;

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

            if (xpgiven == false && stat != null)
            {
                stat.xp = stat.xp + xp;
                xpgiven = true;
            }
            if (transperency < 0)
            {
                Destroy(gameObject);
            }
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
    public void HurtByPlayer(float damage, StatManager sm)
    {
        if (readytotakedamage)
        {
            sprite.color = new Color(1, .5f, .5f, 1);
            HealthBar.healthCurrent -= damage;
            readytotakedamage = false;
            stat = sm;
            if (HealthBar.healthCurrent <= 0)
            {
                dead = true;
            }
        }
    }
    public void OnMouseOver()
    {
        if (dead && clicked == false)
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
        if (dead && clicked == false)
        {
            GameObject lootbox = Instantiate(loot, transform.position, Quaternion.Euler(0, 0, 0));
            lootbox.transform.parent = gameObject.transform;
            Loot stat1 = lootbox.GetComponent<Loot>();
            stat1.sm = stat;
            clicked = true;

        }
    }
}