using UnityEngine;

public class AttackSensor : MonoBehaviour {
    public StatManager Stat;
    public NetworkCharacterController player;
    public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        damage = Stat.damage;
	}
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Cricket"))
        {
            other.gameObject.GetComponent<MeleeEnemyBehaviour>().HurtByPlayer(damage,Stat);          
        }

        if (other.gameObject.CompareTag("Beetle"))
        {
            other.gameObject.GetComponent<MeleeEnemyBehaviour>().HurtByPlayer(damage, Stat);
        }
        if (other.gameObject.CompareTag("Bat"))
        {
            other.gameObject.GetComponent<RangedEnemyBehaviour>().HurtByPlayer(damage, Stat);
        }

        if (other.gameObject.CompareTag("Crow"))
        {
            other.gameObject.GetComponent<RangedEnemyBehaviour>().HurtByPlayer(damage, Stat);
        }


        if (other.gameObject.CompareTag("Mage"))
        {
            other.gameObject.GetComponent<RangedEnemyBehaviour>().HurtByPlayer(damage, Stat);

        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<NetworkCharacterController>().Hurt(damage);

        }
    }
}
