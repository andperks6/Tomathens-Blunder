using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSorceryspell : MonoBehaviour {
    public SpriteRenderer sprite;
    public CharacterController parent;
    public float fireBallSpeed;
    public float deleteTimer;
    private Transform fireBallSpot;
    private Vector3 vs;
    private bool shoot;
    public float spawnWaitTime;
    // Use this for initialization
    void Start()
    {
        
        sprite = GetComponent<SpriteRenderer>();
        fireBallSpot = parent.ProjectileSpot;
        if (parent.PointP == 1)
        {
            transform.Rotate(0, 0, 90);
            vs = new Vector2(transform.position.x + 10, transform.position.y);
        }

        if (parent.PointP == 2)
        {
            transform.Rotate(0, 0, 270);
            vs = new Vector2(transform.position.x - 10, transform.position.y);
        }

        if (parent.PointP == 3)
        {
            transform.Rotate(0, 0, 180);
            vs = new Vector2(transform.position.x, transform.position.y + 10);
        }

        if (parent.PointP == 4)
        {
            transform.Rotate(0, 0, 0);
            vs = new Vector2(transform.position.x, transform.position.y - 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.dead == true)
        {
            Destroy(gameObject);
        }
        deleteTimer = deleteTimer - Time.deltaTime;

        if (parent.shoot == true)
        {
            shoot = true;

        }

        if (shoot == true)
        {



            gameObject.transform.parent = null;



            transform.position = Vector3.MoveTowards(transform.position, vs, fireBallSpeed);
            if (deleteTimer < 0 || transform.position == vs)
            {
                Destroy(gameObject);
            }
        }
    }
}
