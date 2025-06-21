using UnityEngine;

public class EnemySpell : MonoBehaviour {

    public SpriteRenderer sprite;
    public RangedEnemyBehaviour parent;
    public float fireBallSpeed;
    public float deleteTimer;
    private Vector3 fireBallSpot;
    private bool shoot;
    public float spawnWaitTime;
	// Use this for initialization
	void Start () {
        parent = GetComponentInParent<RangedEnemyBehaviour>();
        sprite = GetComponent<SpriteRenderer>();
        fireBallSpot = parent.projectileS;
        if (parent.PointP == 1)
        {
            transform.Rotate(0, 0, 0);
        }

        if (parent.PointP == 2)
        {
            transform.Rotate(0, 0, 90);
        }

        if (parent.PointP == 3)
        {
            transform.Rotate(0, 0, 180);
        }

        if (parent.PointP == 4)
        {
            transform.Rotate(0, 0, 270);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.dead)
        {
            Destroy(gameObject);
        }
        deleteTimer = deleteTimer - Time.deltaTime;

        if (parent.Shoot)
        {
            shoot = true;
            
        }

        if (shoot)
        {

            

            gameObject.transform.parent = null;

            

            transform.position = Vector3.MoveTowards(transform.position, fireBallSpot, fireBallSpeed);
            if (deleteTimer < 0 || transform.position == fireBallSpot)
            {
                Destroy(gameObject);
            }
        }
    }
	
}
