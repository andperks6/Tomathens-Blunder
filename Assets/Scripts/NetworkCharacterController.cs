using UnityEngine;
using Mirror;
using UnityEngine.Serialization;


public class NetworkCharacterController :NetworkBehaviour {
    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rigidBoi;
    [FormerlySerializedAs("SM")] public StatManager sm;
    public InterfaceMain ifm;
    public SpellData sd;
    public Transform mainCamera;
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
    private bool yCurrent;
    [FormerlySerializedAs("Xrange")] public float xrange;
    [FormerlySerializedAs("Yrange")] public float yrange;
    [FormerlySerializedAs("ProjectileSpot")] public Transform projectileSpot;
    public Transform holster;
    public bool rangedAtk;
    public GameObject spell;
    [FormerlySerializedAs("Interface")] public GameObject @interface;
    public bool dead;
    public float damage;
    [FormerlySerializedAs("HealthBar")] public Health healthBar;
    public bool readytotakedamage;
    public BoxCollider2D collison;
    private float transperency;
    public string mytag;
    private float colorChangeTimer;
    public string race;
    public string spelltype;
    public float manaCost;
    [FormerlySerializedAs("PointP")] public int pointP;
    public bool shoot;
    private bool cast;
    private float casttime;
    private static readonly int MoveY = Animator.StringToHash("MoveY");
    private static readonly int MoveX = Animator.StringToHash("MoveX");
    private static readonly int Dead = Animator.StringToHash("Dead");
    private static readonly int Moving = Animator.StringToHash("Moving");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Cast = Animator.StringToHash("Cast");
    private static readonly int LastMoveX = Animator.StringToHash("LastMoveX");
    private static readonly int LastMoveY = Animator.StringToHash("LastMoveY");


    // Use this for initialization
    void Start () {
        if (isLocalPlayer)
        {
            casttime = 1;
            GameObject menu = Instantiate(@interface, transform.position, Quaternion.Euler(0, 0, 0));
            menu.transform.parent = transform;

            anim = GetComponent<Animator>();
            rigidBoi = GetComponent<Rigidbody2D>();
            sprite = GetComponent<SpriteRenderer>();
            collison = GetComponent<BoxCollider2D>();
            sm = GetComponent<StatManager>();
            if (Camera.main != null) mainCamera = Camera.main.transform;
            attacktimer = -1;
            playerNumber = 1;
            readytotakedamage = true;
            transperency = 1;
            colorChangeTimer = .4f;
            moveSpeed = sm.movespeed;
            ifm = menu.GetComponentInChildren<InterfaceMain>();
            ifm.statmanager = sm;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;
        shoot = false;


        if (dead == false)
        {
            xCurrent = false;
            yCurrent = false;
            string playername = playerNumber.ToString();
            gameObject.name = playername;
            var position = transform.position;
            mainCamera.position = Vector3.Lerp(position, place, .15f);
            place = new Vector3(position.x, position.y, -200);
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
                yCurrent = true;

            }
            if (xCurrent && yCurrent == false)
            {
                transform.localScale = xsize;

            }
            if (yCurrent && xCurrent == false)
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
                anim.SetFloat(MoveY, (Input.GetAxisRaw("Vertical")));
                anim.SetFloat(MoveX, 0);

            }
            if (yCurrent == false)
            {
                anim.SetFloat(MoveX, (Input.GetAxisRaw("Horizontal")));
                anim.SetFloat(MoveY, 0);

            }

            anim.SetBool(Dead, dead);
            anim.SetBool(Moving, playerMoving);
            anim.SetBool(Attack, attack);
            anim.SetBool(Cast, cast);
            anim.SetFloat(LastMoveX, lastMove.x);
            anim.SetFloat(LastMoveY, lastMove.y);

            if (Input.GetKeyDown(KeyCode.E) && attacktimer < 0)
            {
                if (rangedAtk)
                {
                    GameObject wind = Instantiate(spell, projectileSpot.position, Quaternion.Euler(0, 0, 0));
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
                moveSpeed = sm.movespeed;
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
            anim.SetBool(Dead, true);
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
            pointP = 1;
            projectileSpot.transform.localPosition = new Vector2(-1.1f, .9f);
        }
        if (lastMove.x == -1)
        {//left
            pointP = 2;
            projectileSpot.transform.localPosition = new Vector2(1, 1);
        }
        if (lastMove.y == 1)
        {//up
            projectileSpot.transform.localPosition = new Vector2(.9f, .9f);
            pointP = 3;
        }
        if (lastMove.y == -1)
        {//down
            projectileSpot.transform.localPosition = new Vector2(1, 1);
            pointP = 4;
        }
        if (Input.GetKeyDown(KeyCode.Q) && cast == false)
        {
            if (spelltype == "Sorcery" && manaCost < sm.magickaCurrent && sd.castable)
            {
                cast = true;
                GameObject sorc = Instantiate(spell, projectileSpot.position, Quaternion.Euler(0, 0, 0));
                PlayerSorceryspell pss = sorc.GetComponent<PlayerSorceryspell>();
                pss.parent = gameObject.GetComponent<NetworkCharacterController>();

                sm.magickaCurrent = sm.magickaCurrent - manaCost;
                sd.startcd = true;

            }


        }
        if (cast)
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

    public void Hurt(float dmg)
    {
        if (readytotakedamage)
        {
            sprite.color = new Color(1, .5f, .5f, 1);
            healthBar.healthCurrent -= dmg;
            
            if (healthBar.healthCurrent <= 0)
            {
                dead = true;
            }
        }
    }
}
