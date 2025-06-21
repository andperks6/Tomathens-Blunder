using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour {
    public NetworkCharacterController parent;
    public float Speed;
    public float deleteTimer;
    public Transform ProjectileSpot;
    public Vector3 spellend;
    public bool shoot;
    private float rotation;
    private float distanceX;
    private float distanceY;
    public Vector2 playerRot;
    public float waittime;
    // Use this for initialization
    void Start()
    {
        parent = GetComponentInParent<NetworkCharacterController>();
        playerRot = parent.lastMove;     
        ProjectileSpot = parent.projectileSpot;
        if (playerRot.x == -1)
        {
            distanceX = -15;
            distanceY = 0;
        }
        if (playerRot.x == 1)
        {
            distanceX = 15;
            distanceY = 0;
        }
        if (playerRot.y == -1)
        {
            distanceY = -15;
            distanceX = 0;
        }
        if (playerRot.y == 1)
        {
            distanceY = 15;
            distanceX = 0;
        }
        spellend = new Vector3(ProjectileSpot.position.x + distanceX, ProjectileSpot.position.y + distanceY, ProjectileSpot.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        deleteTimer = deleteTimer - Time.deltaTime;

        if (parent.attack)
        {
            shoot = true;

        }

        if (shoot)
        {
            waittime = waittime - Time.deltaTime;

            if (waittime < 0)
            {
                gameObject.transform.parent = null;


                transform.position = Vector3.MoveTowards(transform.position, spellend, Speed);
            }
            if (deleteTimer < 0 )
            {
                Destroy(gameObject);
            }
        }
    }

}

