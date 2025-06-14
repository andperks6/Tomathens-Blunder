using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantShop : MonoBehaviour {
    public Transform[] slots;
    public GameObject[] itemsforsale;
    public StatManager playerStat;
    public bool closeShop;
    public float coin;
    public int whichItem;
    public ShopSenor playerinfo;
    public Vector3 spawnPoint;
    private bool buy1;
    private int onlybuyonce;
    private int coinDed;
    public int whichStore;
    public bool isspell;
    public int window;
    public ShopText sp;

    // Use this for initialization
    void Start () {
        window = 1;
       

	}
	
	// Update is called once per frame
	void Update () {
        coin = playerinfo.playerGold;
        
        sp.content = coin.ToString();
        if (whichStore == 1)
        {
            if (buy1 == true && onlybuyonce != whichItem)
                //be sure to redo all the costs, theyre all at 1 coin just for testing.
            {
                if (whichItem == 1 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 1, isspell);
                    buy1 = false;
                }
                if (whichItem == 2 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 2, isspell);
                    buy1 = false;
                }
                if (whichItem == 3 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 3, isspell);
                    buy1 = false;
                }
                if (whichItem == 4 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 4, isspell);
                    buy1 = false;
                }
                if (whichItem == 5 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 5, isspell);
                    buy1 = false;
                }
                if (whichItem == 6 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 6, isspell);
                    buy1 = false;
                }
                if (whichItem == 7 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 7, isspell);
                    buy1 = false;
                }
                if (whichItem == 8 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 8, isspell);
                    buy1 = false;
                }
                if (whichItem == 9 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 9, isspell);
                    buy1 = false;
                }
                if (whichItem == 10 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 10, isspell);
                    buy1 = false;
                }
                if (whichItem == 11 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 11, isspell);
                    buy1 = false;
                }
                if (whichItem == 12 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 12, isspell);
                    buy1 = false;
                }
                if (whichItem == 13 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 13, isspell);
                    buy1 = false;
                }
                if (whichItem == 14 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 14, isspell);
                    buy1 = false;
                }
                if (whichItem == 15 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 15, isspell);
                    buy1 = false;
                }
                if (whichItem == 16 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 16, isspell);
                    buy1 = false;
                }
                if (whichItem == 17 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 17, isspell);
                    buy1 = false;
                }
                if (whichItem == 18 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 18, isspell);
                    buy1 = false;
                }
                if (whichItem == 19 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 19, isspell);
                    buy1 = false;
                }
                if (whichItem == 20 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1,20, isspell);
                    buy1 = false;
                }
                if (whichItem == 21 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 21, isspell);
                    buy1 = false;
                }
                if (whichItem == 22 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 22, isspell);
                    buy1 = false;
                }
                if (whichItem == 23 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 23, isspell);
                    buy1 = false;
                }
                if (whichItem == 24 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 24, isspell);
                    buy1 = false;
                }
                if (whichItem == 25 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 25, isspell);
                    buy1 = false;
                }
                if (whichItem == 26 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 26, isspell);
                    buy1 = false;
                }
                if (whichItem == 27 && coin > 1)
                {
                    playerStat.GetComponent<StatManager>().itemBought(1, 27, isspell);
                    buy1 = false;
                }
            }
        }
        if (whichStore == 2)
        {
            if (buy1 == true )

            {
                if (whichItem == 1 && coin > 9)
                {
                    playerStat.GetComponent<StatManager>().KeyBought(1, 1);
                    buy1 = false;
                }
                if (whichItem == 2 && coin > 9)
                {
                    playerStat.GetComponent<StatManager>().KeyBought(1, 2);
                    buy1 = false;
                }
                if (whichItem == 3 && coin > 9)
                {
                    playerStat.GetComponent<StatManager>().KeyBought(1, 3);
                    buy1 = false;
                }
                if (whichItem == 4 && coin > 9)
                {
                    playerStat.GetComponent<StatManager>().KeyBought(1, 4);
                    buy1 = false;
                }
                if (whichItem == 5 && coin > 9)
                {
                    playerStat.GetComponent<StatManager>().KeyBought(1, 5);
                    buy1 = false;
                }
                if (whichItem == 6 && coin > 9)
                {
                    playerStat.GetComponent<StatManager>().KeyBought(1 ,6);
                    buy1 = false;
                }
                if (whichItem == 7 && coin > 9)
                {
                    playerStat.GetComponent<StatManager>().KeyBought(1 , 7);
                    buy1 = false;
                }
                if (whichItem == 8 && coin > 9)
                {
                    playerStat.GetComponent<StatManager>().KeyBought(1 , 8);
                    buy1 = false;
                }
               

            }
        }

    }
    public void closeshop()
    {
        gameObject.SetActive(false);
    }
    public void buy()
    {
        buy1 = true;
        playerStat = playerinfo.player;
    }

    public void whichItem1(int identifier, bool spell)
    {
        whichItem = identifier;
        isspell = spell;
    }

}
