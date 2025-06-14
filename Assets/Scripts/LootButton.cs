using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootButton : MonoBehaviour {

    public bool size;

    public Loot parent;
    


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (size == false)
        {
            transform.localScale = new Vector3(1f, 1f, 1);
        }
        if (size == true)
        {
            transform.localScale = new Vector3(1.05f, 1.05f, 1);
            size = false;
        }
        
       

    }
    public void OnMouseOver()
    {
        size = true;
    }
    public void OnMouseDown()
    {
        Loot close = parent.GetComponent<Loot>();
        close.show = false;
    }
}
