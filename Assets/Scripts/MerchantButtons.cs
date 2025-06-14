using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantButtons : MonoBehaviour {

    public bool size;
    public MerchantShop merchant;
    public int whichItem;
    public float coin;
    public SpriteRenderer sprite;
    private float colorChange;
    public bool back;
    private Animator anim;
    private bool oneclick;



    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        oneclick = false;
        if (size == false)
        {
            transform.localScale = new Vector3(.5f, .5f, 1);
        }
        if (size == true)
        {
            transform.localScale = new Vector3(.6f, .6f, 1);
            size = false;
        }
       if (colorChange > 0)
        {
            colorChange = colorChange - Time.deltaTime;
        }
       else { sprite.color = new Color(1f, 1f, 1f, 1); }
       


    }
    public void OnMouseOver()
    {
        size = true;
    }
    public void OnMouseDown()
    {
        if (gameObject.tag == "Close")
        {
            merchant.GetComponent<MerchantShop>().closeshop();
            sprite.color = new Color(.5f, .5f, .5f, 1);
            colorChange = .2f;
        }
        if (gameObject.tag == "Next" && back == true && oneclick == false)
        {
            merchant.window = 1;
            sprite.color = new Color(.5f, .5f, .5f, 1);
            colorChange = .2f;
            back = false;
            anim.SetBool("back", back);
            oneclick = true;
        }
        if (gameObject.tag == "Next" && back == false && oneclick == false)
        {
            merchant.window = 2;
            sprite.color = new Color(.5f, .5f, .5f, 1);
            colorChange = .2f;
            back = true;
            anim.SetBool("back", back);
            oneclick = true;
            
        }
        
        if (gameObject.tag == "Buy")
        {
            merchant.GetComponent<MerchantShop>().buy();
            sprite.color = new Color(.5f, .5f, .5f, 1);
            colorChange = .2f;
        }


    }
    

}
