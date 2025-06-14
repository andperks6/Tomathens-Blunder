using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemySensor : MonoBehaviour {

    public bool aggressive;
    public RangedEnemyBehaviour hot;
    public string whichPlayer;
    public string whichTag;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        aggressive = false;


    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Player")
        {

            aggressive = true;
            hot.aggresive = aggressive;
            whichPlayer = other.gameObject.name;
            whichTag = other.gameObject.tag;
            hot.WP = whichPlayer;
            hot.EnemyTag = whichTag;
        }
        if (other.gameObject.tag == "DeadPlayer")
        {




            whichTag = other.gameObject.tag;

            hot.EnemyTag = whichTag;
        }

    }
}