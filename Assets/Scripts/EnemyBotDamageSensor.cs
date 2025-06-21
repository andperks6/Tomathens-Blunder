using UnityEngine;

public class EnemyBotDamageSensor : MonoBehaviour {

    public MeleeEnemyBehaviour bot;
    public float damage;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        damage = bot.damage;
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<NetworkCharacterController>().Hurt(damage);
            bot.EnemyTag = "Player";

        }

        if (other.gameObject.tag == "Moth")
        {
            other.gameObject.GetComponent<MothMovement>().Hurt(damage);
            bot.EnemyTag = "Moth";

        }
        if (other.gameObject.tag == "DeadPlayer")
        {
            bot.aggresive = false;
            bot.EnemyTag = "DeadPlayer";
               

        }
        
    }
}
