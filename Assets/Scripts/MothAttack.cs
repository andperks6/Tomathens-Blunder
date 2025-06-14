using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothAttack : MonoBehaviour {

    public MothMovement parent;
    public float Speed;
    public float deleteTimer;
    public Vector3 ProjectileSpot;
    public Vector3 spellend;
    public bool shoot;
    private float rotation;
    private float distanceX;
    private float distanceY;
    public Vector2 playerRot;
    public float waittime;
    public float damage2;
    public StatManager sm;

    // Use this for initialization
    void Start()
    {
        parent = GetComponentInParent<MothMovement>();
        playerRot = parent.lastMove;
        ProjectileSpot = parent.projectileSpot;
        if (playerRot.x == -1)
        {
            distanceX = -15;
            distanceY = 0;
            transform.Rotate(0, 0, 90);

        }
        if (playerRot.x == 1)
        {
            distanceX = 15;
            distanceY = 0;
            transform.Rotate(0, 0, 90);
        }
        if (playerRot.y == -1)
        {
            distanceY = -15;
            distanceX = 0;
            transform.Rotate(0, 0, 0);
        }
        if (playerRot.y == 1)
        {
            distanceY = 15;
            distanceX = 0;
            transform.Rotate(0, 0, 0);
        }
        spellend = new Vector3(ProjectileSpot.x + distanceX, ProjectileSpot.y + distanceY, ProjectileSpot.z);

    }

    // Update is called once per frame
    void Update()
    {
        damage2 = parent.damage;
        deleteTimer = deleteTimer - Time.deltaTime;

        if (parent.attack == true)
        {
            shoot = true;

        }

        if (shoot == true)
        {
            waittime = waittime - Time.deltaTime;

            if (waittime < 0)
            {
                gameObject.transform.parent = null;


                transform.position = Vector3.MoveTowards(transform.position, spellend, Speed);
            }
            if (deleteTimer < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Cricket")
        {
            other.gameObject.GetComponent<MeleeEnemyBehaviour>().HurtByPlayer(damage2,sm);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Mage")
        {
            other.gameObject.GetComponent<RangedEnemyBehaviour>().HurtByPlayer(damage2,sm);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterController>().Hurt(damage2);
            Destroy(gameObject);
        }
        

    }
}
