using UnityEngine;

public class MothAnimation : MonoBehaviour {


    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;
    public bool attack;
    private float attacktimer;
    public int playerNumber;
    public bool xCurrent;
    public bool YCurrent;
    public MothMovement parent;
    private SpriteRenderer sprite;
    private float transperency;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        attacktimer = -1;
        sprite = GetComponent<SpriteRenderer>();
        transperency = 1;


    }

    // Update is called once per frame
    void Update()
    {
        if (parent.dead == false)
        {
            playerMoving = false;
            xCurrent = false;
            YCurrent = false;

            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {

                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                xCurrent = true;
                anim.SetFloat("MoveY", 0);



            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {

                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                YCurrent = true;
                anim.SetFloat("MoveX", 0);
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
            anim.SetBool("Moving", playerMoving);
            anim.SetBool("Attack", attack);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);

            if (Input.GetKeyDown(KeyCode.E) && attacktimer < 0)
            {
                attack = true;
                attacktimer = .8f;


            }

            if (attacktimer > 0)
            {
                attacktimer = attacktimer - Time.deltaTime;
            }
            if (attacktimer < 0)
            {
                attack = false;

            }
        }
        else
        {
            anim.SetBool("Dead", true);
            sprite.sortingOrder = 9;
            sprite.color = new Color(1, 1, 1, transperency);
            transperency = transperency - .001f;
            if (transperency < 0)
            {
                Destroy(gameObject);
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {





    }
}