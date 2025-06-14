using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour {

    public UserInterface UI;
    private TextMeshPro text1;
    public float number;
    private bool openMenu;
    public bool decorative;
    public bool showing;
    public int tab;
    public int whichTab;
    

    
	// Use this for initialization
	void Start () {
        
        text1 = GetComponent<TextMeshPro>();
        number = 0;

    }
	
	// Update is called once per frame
	void Update () {

        whichTab = UI.ptab;
        
        if (decorative == false)
        {
            text1.text = number.ToString();
        }
        if (UI.openMenu == true)
        {
            text1.enabled = true;
        }
        if (UI.openMenu == false || whichTab == 2 || whichTab == 3 || whichTab == 4)
        {
            text1.enabled = false;
        }
    }
   
   
}
