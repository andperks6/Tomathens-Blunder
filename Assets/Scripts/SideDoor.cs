using UnityEngine;

public class SideDoor : MonoBehaviour

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
        anim.SetBool("Brown", brown);
        anim.SetBool("Red", red);
        anim.SetBool("Teal", teal);
        anim.SetBool("Purple", purple);
        anim.SetBool("Green", green);
        anim.SetBool("Blue", blue);
        anim.SetBool("Yellow", yellow);
        anim.SetBool("Darkyellow", darkyellow);
        anim.SetBool("Orange", orange);
        anim.SetBool("Lavender", lavender);






        if (open)
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
