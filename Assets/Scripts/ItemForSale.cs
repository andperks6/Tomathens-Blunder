using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemForSale : MonoBehaviour {

    public bool size;
    public MerchantShop shop;
    public ShopText description;
    public int identifier;
    public string script;
    private Vector3 size1;
    public GameObject background;
    public GameObject select;
    public bool spell;
    public int window;
    private SpriteRenderer sprite;
    private BoxCollider2D box2d;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        box2d = GetComponent<BoxCollider2D>();
        size1 = new Vector3(transform.localScale.x, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {

        if (size == false)
        {
            transform.localScale = new Vector3(size1.x,size1.y);
        
        }
        if (size == true)
        {
            transform.localScale = new Vector3(size1.x + .1f, size1.y + .1f);
            size = false;
        }
        if (window == shop.window)
        {
            sprite.enabled = true;
            box2d.enabled = true;
        }
        else
        {
         box2d.enabled = false;
         sprite.enabled = false;
        }

    }
    public void OnMouseOver()
    {
        background.SetActive(true);
        size = true;
        description.content = script;
        description.showing = true;
    }
    public void OnMouseExit()
    {
        background.SetActive(false);
        description.showing = false;

    }
    public void OnMouseDown()
    {
        if (window == shop.window)
        {
            select.SetActive(true);
            select.transform.position = new Vector2(transform.position.x, transform.position.y);
            shop.GetComponent<MerchantShop>().whichItem1(identifier, spell);
        }
    }
}
