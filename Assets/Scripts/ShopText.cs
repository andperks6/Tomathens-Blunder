using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopText : MonoBehaviour {


    private TextMeshPro text1;
    
    public string content;
    private bool openMenu;
    public bool decorative;
    public bool showing;

    



    // Use this for initialization
    void Start()
    {
        text1 = GetComponent<TextMeshPro>();
       

    }

    // Update is called once per frame
    void Update()
    {
        
        if (decorative == false)
        {
            text1.text = content;
        }
       if (showing == true)
        {
            text1.sortingOrder = 211;
                
        }
       else { text1.sortingOrder = 1; }
    }
}
