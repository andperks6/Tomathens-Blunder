using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class CharacterController :NetworkBehaviour {
    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rigidBoi;
    public StatManager SM;
    public InterfaceMain ifm;
    public SpellData sd;
    Transform camera;
    private bool playerMoving;
    public Vector3 place;
    public float moveSpeed;
    public Vector2 lastMove;
    public bool attack;
    private float attacktimer;
    public float attacktimerChange;
    public int playerNumber;
    public Vector3 ysize;
    public Vector3 xsize;
    private bool xCurrent;
    private bool YCurrent;
    public float Xrange;
    public float Yrange;
    public Transform ProjectileSpot;
    public Transform holster;
    public bool rangedAtk;
    public GameObject spell;
    public GameObject Interface;
    public bool dead;
    public float damage;
    public Health HealthBar;
    public bool readytotakedamage;
    public BoxCollider2D collison;
    private float transperency;
    public string mytag;
    private float colorChangeTimer;
    public string race;
    public string spelltype;
    public float manaCost;
    public int PointP;
    public bool shoot;
    private bool cast;
    private float casttime;




    // Use this for initialization
    void Start () {
        if (isLocalPlayer)
        {
            casttime = 1;
            GameObject Menu = (GameObject)Instantiate(Interface, transform.position, Quaternion.Euler(0, 0, 0));
            Menu.transform.parent = transform;

            anim = GetComponent<Animator>();
            rigidBoi = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
            collison = GetComponent<BoxCollider2D>();
            SM = GetComponent<StatManager>();
            camera = Camera.main.transform;
            attacktimer = -1;
            playerNumber = 1;
            readytotakedamage = true;
            transperency = 1;
            colorChangeTimer = .4f;
            moveSpeed = SM.movespeed;
            ifm = Menu.GetComponentInChildren<InterfaceMain>();
            ifm.statmanager = SM;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isLocalPlayer)
        {
            shoot = false;


            if (dead == false)
            {


                xCurrent = false;
                YCurrent = false;
                string playername = playerNumber.ToString();
                gameObject.name = playername;
                camera.position = Vector3.Lerp(transform.position, place, .15f);
                place = new Vector3(transform.position.x, transform.position.y, -200);
                playerMoving = false;


                if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
                {

                    playerMoving = true;
                    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                    rigidBoi.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigidBoi.velocity.y);
                    xCurrent = true;

                }
                if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
                {

                    playerMoving = true;
                    lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                    rigidBoi.velocity = new Vector2(rigidBoi.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                    YCurrent = true;

                }
                if (xCurrent == true && YCurrent == false)
                {
                    transform.localScale = xsize;

                }
                if (YCurrent == true && xCurrent == false)
                {
                    transform.localScale = ysize;
                }

                if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
                {
                    rigidBoi.velocity = new Vector2(0f, rigidBoi.velocity.y);

                }
                if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
                {
                    rigidBoi.velocity = new Vector2(rigidBoi.velocity.x, 0f);

                }
                if (xCurrent == false)
                {
                    anim.SetFloat("MoveY", (Input.GetAxisRaw("Vertical")));
                    anim.SetFloat("MoveX", 0);

                }
                if (YCurrent == false)
                {
                    anim.SetFloat("MoveX", (Input.GetAxisRaw("Horizontal")));
                    anim.SetFloat("MoveY", 0);

                }

                anim.SetBool("Dead", dead);
                anim.SetBool("Moving", playerMoving);
                anim.SetBool("Attack", attack);
                anim.SetBool("Cast", cast);
                anim.SetFloat("LastMoveX", lastMove.x);
                anim.SetFloat("LastMoveY", lastMove.y);

                if (Input.GetKeyDown(KeyCode.E) && attacktimer < 0)
                {
                    if (rangedAtk == true)
                    {
                        GameObject wind = (GameObject)Instantiate(spell, ProjectileSpot.position, Quaternion.Euler(0, 0, 0));
                        wind.transform.parent = transform;
                    }

                    attack = true;
                    attacktimer = attacktimerChange;
                    moveSpeed = .8f;

                }

                if (attacktimer > 0)
                {
                    attacktimer = attacktimer - Time.deltaTime;
                }
                if (attacktimer < 0)
                {
                    attack = false;
                    moveSpeed = SM.movespeed;
                }
                if (colorChangeTimer > 0)
                {
                    colorChangeTimer = colorChangeTimer - Time.deltaTime;
                }
                else
                {

                    sprite.color = new Color(1, 1, 1, 1);
                    colorChangeTimer = .4f;
                }

            }
            else
            {

                sprite.sortingOrder = 9;
                collison.enabled = false;
                anim.SetBool("Dead", true);
                sprite.color = new Color(1, 1, 1, transperency);
                transperency = transperency - .001f;
                transform.gameObject.tag = "DeadPlayer";
                if (transperency < 0)
                {
                    Destroy(gameObject);
                }
            }
            if (lastMove.x == 1)
            {//right
                PointP = 1;
                ProjectileSpot.transform.localPosition = new Vector2(-1.1f, .9f);
            }
            if (lastMove.x == -1)
            {//left
                PointP = 2;
                ProjectileSpot.transform.localPosition = new Vector2(1, 1);
            }
            if (lastMove.y == 1)
            {//up
                ProjectileSpot.transform.localPosition = new Vector2(.9f, .9f);
                PointP = 3;
            }
            if (lastMove.y == -1)
            {//down
                ProjectileSpot.transform.localPosition = new Vector2(1, 1);
                PointP = 4;
            }
            if (Input.GetKeyDown(KeyCode.Q) && cast == false)
            {
                if (spelltype == "Sorcery" && manaCost < SM.magickaCurrent && sd.castable == true)
                {
                    cast = true;
                    GameObject sorc = (GameObject)Instantiate(spell, ProjectileSpot.position, Quaternion.Euler(0, 0, 0));
                    PlayerSorceryspell pss = sorc.GetComponent<PlayerSorceryspell>();
                    pss.parent = gameObject.GetComponent<CharacterController>();

                    SM.magickaCurrent = SM.magickaCurrent - manaCost;
                    sd.startcd = true;

                }


            }
            if (cast == true)
            {

                casttime = casttime - Time.deltaTime;
                if (casttime < .5f)
                {
                    shoot = true;
                }
                if (casttime < 0)
                {

                    cast = false;
                    casttime = 1;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {


       


    }
    public void Hurt(float damage)
    {
        if (readytotakedamage == true)
        {
            sprite.color = new Color(1, .5f, .5f, 1);
            HealthBar.healthCurrent -= damage;
            
            if (HealthBar.healthCurrent <= 0)
            {
                dead = true;
            }
        }
    }
}
