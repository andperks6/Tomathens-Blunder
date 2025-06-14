using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : MonoBehaviour {
    Transform camera;
    public SpriteRenderer sprite;
    public bool openMenu;
    public bool sub;
    public int ptab;
    public int whichTab;
	// Use this for initialization
	void Start () {
        
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        Text child = GetComponentInChildren<Text>();
        ptab = 1;
    }
	
	// Update is called once per frame
	void Update () {
        
       
        if (Input.GetKeyDown("tab"))
        {
            openMenu = !openMenu;

        }

        if (openMenu == true)
        {
            sprite.enabled = true;
            
            

        }
        if (openMenu == false)
        {
            sprite.enabled = false;
           
           
        }
        if (sub == true)
        {
            if (whichTab == ptab)
            {
                sprite.enabled = true;
            }
            else { sprite.enabled = false; }
        }
    }
}
