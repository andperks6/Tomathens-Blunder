using UnityEngine;

public class Cricketmovement : MonoBehaviour {
    
    public bool turn;
    public float touchtimer;
    public bool touched;
    public bool wall;
    public float stuckCounter;
    public float stuckFeedback;
    public bool free;
    // Use this for initialization
    void Start() {
        free = false;
        turn = false;
        touchtimer = 1f;
        stuckFeedback = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (stuckCounter < 5)
        {
            stuckCounter = stuckCounter - Time.deltaTime;
            if (stuckCounter < 0 && stuckFeedback > 2)
            {
                free = true;
                stuckFeedback = 0;
                stuckCounter = 4.5f;

            }
            if (stuckCounter < 0 && stuckFeedback <= 2)
            {
                
                stuckFeedback = 0;
                stuckCounter = 4.5f;

            }

        }

        if (touched)
        {
            
            turn = false;
            touchtimer = touchtimer - Time.deltaTime;
            if (touchtimer < 0)
            {
                touched = false;
                touchtimer = 1;
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
          
         
        if (other.gameObject.tag == "collisionblocks" && touchtimer == 1 )
        {
            
            turn = true;
            touched = true;
            stuckFeedback++;
        }
        if (other.gameObject.tag == "Cricket" && touchtimer == 1)
        {

            turn = true;
            touched = true;
            stuckFeedback++;
        }

    }
    
}

        
