using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {
    public bool size;
    public int tab;
    public UserInterface parent;
    public Animator anim;
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        tab = parent.ptab;
        if (size == false)
        {
            transform.localScale = new Vector3(1f, 1f, 1);
        }
        if (size == true)
        {
            transform.localScale = new Vector3(1.05f, 1.05f, 1);
            size = false;
        }
        anim = GetComponent<Animator>();
        anim.SetInteger("Tab", tab);

    }
   public void OnMouseOver()
    {
        size = true;
    }
    public void OnMouseDown()
    {
        if (tag == "Overview")
        {
            tab = 1;
           
        }
        if (tag == "Magic")
        {
            tab = 2;
        }
        if (tag == "Misc")
        {
            tab = 3;
        }
        if (tag == "Settings")
        {
            tab = 4;
        }
        parent.ptab = tab;
        anim.SetInteger("Tab", tab);
    }
}
