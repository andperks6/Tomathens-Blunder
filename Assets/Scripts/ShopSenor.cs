using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSenor : MonoBehaviour {
    public StatManager player;
    public ShopSenor otherShop;
    public GameObject text;
    public GameObject shop;
    public bool readytobuy;
    private float buytimer;
    public float playerGold;
	// Use this for initialization
	void Start () {
        buytimer = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        if (otherShop.readytobuy == true)
        {
            if (otherShop.buytimer > buytimer)
            {
                
                buytimer = -1;
            }
        }
       
        if (readytobuy == true)
        {
            playerGold = player.gold;
            buytimer = buytimer -Time.deltaTime;
            if (buytimer < 0)
            {
                readytobuy = false;
                text.SetActive(false);
                buytimer = 3;
            }
        }
        if (Input.GetKeyDown("x") && readytobuy == true)
        {
            shop.SetActive(true);
            text.SetActive(false);
        }
        

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            readytobuy = true;
            player = other.gameObject.GetComponent<StatManager>();
           
        }

    }
   
  }
