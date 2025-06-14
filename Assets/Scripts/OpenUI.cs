using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour {
    public bool openMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown("tab"))
        {
            openMenu = !openMenu;
         
        }
       
    }
}
