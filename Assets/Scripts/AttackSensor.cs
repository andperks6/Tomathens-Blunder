using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSensor : MonoBehaviour {
    public StatManager Stat;
    public CharacterController player;
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


        if (other.gameObject.tag == "Cricket")
        {
            other.gameObject.GetComponent<MeleeEnemyBehaviour>().HurtByPlayer(damage,Stat);          
        }

        if (other.gameObject.tag == "Beetle")
        {
            other.gameObject.GetComponent<MeleeEnemyBehaviour>().HurtByPlayer(damage, Stat);
        }
        if (other.gameObject.tag == "Bat")
        {
            other.gameObject.GetComponent<MeleeEnemyBehaviour>().HurtByPlayer(damage, Stat);
        }

        if (other.gameObject.tag == "Crow")
        {
            other.gameObject.GetComponent<MeleeEnemyBehaviour>().HurtByPlayer(damage, Stat);
        }


        if (other.gameObject.tag == "Mage")
        {
            other.gameObject.GetComponent<RangedEnemyBehaviour>().HurtByPlayer(damage, Stat);

        }
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterController>().Hurt(damage);

        }
    }
}
