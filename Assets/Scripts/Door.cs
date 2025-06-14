using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour

{
    public Animator anim;
    public float doorOpentimer;
    private bool open;
    public bool brown;
    public bool red;
    public bool teal;
    public bool purple;
    public bool green;
    public bool blue;
    public bool yellow;
    public bool darkyellow;
    public bool orange;
    public bool lavender;



    // Use this for initialization
    void Start()
    {
        open = false;
        Animator anim = GetComponentInParent<Animator>();
        doorOpentimer = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("brown", brown);
        anim.SetBool("red", red);
        anim.SetBool("teal", teal);
        anim.SetBool("purple", purple);
        anim.SetBool("green", green);
        anim.SetBool("blue", blue);
        anim.SetBool("yellow", yellow);
        anim.SetBool("darkyellow", darkyellow);
        anim.SetBool("orange", orange);
        anim.SetBool("lavender", lavender);
        





        if (open == true)
        {
            doorOpentimer = doorOpentimer - Time.deltaTime;
            if (doorOpentimer < 0)
            {
                open = false;
                anim.SetBool("Open", false);
                doorOpentimer = 3.5f;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Open", true);
            open = true;
        }
        
    }
}