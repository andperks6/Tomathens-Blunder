using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothMovement : MonoBehaviour
{
   
    
    private Rigidbody2D rigidBoi;
    Transform camera;
    private bool playerMoving;
    public Vector3 place;
    public float moveSpeed;
    public Vector2 lastMove;
    public bool attack;
    private float attacktimer;
    public int playerNumber;
    public Transform projectile;
    public Vector2 projectileSpot;
    public GameObject spell;
    public Health HealthBar;
    public bool dead;
    public BoxCollider2D collison;
    public float damage;



    // Use this for initialization
    void Start()
    {
        
        rigidBoi = GetComponent<Rigidbody2D>();
       
        collison = GetComponent<BoxCollider2D>();
        camera = Camera.main.transform;
        attacktimer = -1;
        playerNumber = 1;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            projectileSpot = new Vector2(projectile.position.x, projectile.position.y);
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


            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {

                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                rigidBoi.velocity = new Vector2(rigidBoi.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);

            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                rigidBoi.velocity = new Vector2(0f, rigidBoi.velocity.y);

            }
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                rigidBoi.velocity = new Vector2(rigidBoi.velocity.x, 0f);

            }


            if (Input.GetKeyDown(KeyCode.E) && attacktimer < 0)
            {
                GameObject missle = (GameObject)Instantiate(spell, projectileSpot, Quaternion.Euler(0, 0, 0));
                missle.transform.parent = transform;
                attack = true;
                attacktimer = .8f;
                moveSpeed = .8f;

            }

            if (attacktimer > 0)
            {
                attacktimer = attacktimer - Time.deltaTime;
            }
            if (attacktimer < 0)
            {
                attack = false;
                moveSpeed = 6;
            }

        }
        else
        {

           
            collison.enabled = false;
            
            transform.gameObject.tag = "DeadPlayer";
            
        }
    }
    public void Hurt(float damage)
    {
        
            HealthBar.healthCurrent -= damage;

            if (HealthBar.healthCurrent <= 0)
            {
                dead = true;
            }
        
    }
}
