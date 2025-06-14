using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShow : MonoBehaviour {

    Transform camera;
    public SpriteRenderer sprite;
    public InterfaceMain UI;
    public bool openMenu;
    public bool sub;
    public int ptab;
    public float whichTab;
    public bool item;
    public bool sub2;
    


    // Use this for initialization
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        Text child = GetComponentInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        whichTab = UI.tab;
        

        if (UI.openmenu2 == true)
        {
            sprite.enabled = true;



        }
        if (UI.openmenu2 == false)
        {
            sprite.enabled = false;


        }
        if (sub == true )
        {
            if (whichTab == ptab && UI.openmenu2 == true)
            {
                sprite.enabled = true;
            }
            else { sprite.enabled = false; }
        }
     
    }
}
