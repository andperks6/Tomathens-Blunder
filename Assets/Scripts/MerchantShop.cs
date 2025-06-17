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
    public int whichStore; // 1 = items/spells, 2 = keys
    private ItemType currentItemType;
    public int window;
    public ShopText sp;

    private const int NORMAL_ITEM_COST = 1;
    private const int KEY_COST = 9;

    // Use this for initialization
    void Start () {
        window = 1;
       

	}
	
	// Update is called once per frame
	   void Update () {
	       coin = playerinfo.playerGold;
	       sp.content = coin.ToString();

	       if (buy1 && onlybuyonce != whichItem) {
	           bool canAfford = false;
	           int cost = (whichStore == 2) ? KEY_COST : NORMAL_ITEM_COST;
	           
	           if (coin > cost) {
	               canAfford = true;
	               
	               if (whichStore == 1) {
	                   // Regular items and spells
	                   if (whichItem > 0 && whichItem <= 27) {
	                       playerStat.GetComponent<StatManager>().itemBought(1, whichItem, currentItemType == ItemType.Spell);
	                       buy1 = false;
	                   }
	               }
	               else if (whichStore == 2) {
	                   // Keys
	                   if (whichItem > 0 && whichItem <= 8) {
	                       playerStat.GetComponent<StatManager>().KeyBought(1, whichItem);
	                       buy1 = false;
	                   }
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
        currentItemType = spell ? ItemType.Spell : ItemType.Normal;
        if (whichStore == 2) {
            currentItemType = ItemType.Key;
        }
    }

}
