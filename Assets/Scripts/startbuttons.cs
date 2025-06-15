using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class startbuttons : MonoBehaviour
{
    public startscreen nw;
    public int boxident;
    private bool size;
    private Vector3 v3;
    public networktest network;
    public networktest2 parent;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        if (size == false)
        {
            transform.localScale = new Vector3(.5f, .5f, 1);
        }
        if (size == true)
        {
            transform.localScale = new Vector3(.6f, .6f, 1);
            size = false;
        }
        }
        public void OnMouseOver()
        {
            size = true;
        }
        public void OnMouseDown()
        {
        if (gameObject.tag == "PlayerIcon")
        {

            parent.whichRace = boxident;
        }
        // TODO: add switching teams functionality
        //  if (gameObject.tag == "Next")
        //   {
        //             
        //   }
        if (gameObject.tag == "Start")
        {
            parent.addplayer2();

        }
        if (gameObject.tag == "Sell")
        {

        }
    }

}
