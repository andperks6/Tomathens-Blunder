using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEqiup : MonoBehaviour {
    public SpriteRenderer sprite;
    public InterfaceMain im2;
    public SplBank spellbank;
    public SpellData spelldata;
    private bool size;
    private Vector3 size1;
    public int spellident;
    public bool full;
    public int whichBox;
    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        size1 = new Vector3(transform.localScale.x, transform.localScale.y);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (whichBox == 1)
        {
            im2.box1spell = spellident;
        }
        if (whichBox == 2)
        {
            im2.box2spell = spellident;
        }
        if (whichBox == 3)
        {
            im2.box3spell = spellident;
        }
        if (whichBox == 4)
        {
            im2.box4spell = spellident;
        }
        if (whichBox == 5)
        {
            im2.box5spell = spellident;
        }
        if (whichBox == 6)
        {
            im2.box6spell = spellident;
        }

        


        if (im2.spellring == true)
        {
            sprite.enabled = true;
        }
        else { sprite.enabled = false; }
        if (size == false)
        {
            transform.localScale = new Vector3(size1.x, size1.y, 1);
        }
        if (size == true)
        {
            transform.localScale = new Vector3(size1.x + .05f, size1.y + .05f, 1);
            size = false;
        }
    }
    public void OnMouseOver()
    {
        size = true;
    }
    public void OnMouseDown()
    {
        if (im2.spellring == true)
        {
            if (full == false)
            {
                spellident = im2.whichspell;
                GameObject spell = (GameObject)Instantiate(spellbank.spells[spellident], transform.position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                UIShow tpz = spell.GetComponent<UIShow>();
                tpz.UI = im2;
                sd.disbleText = true;
                spelldata = sd;
                sd.time = true;
                full = true;

            }
            if (full == true)
            {
                spelldata.destroy = true;
                spellident = im2.whichspell;
                GameObject spell = (GameObject)Instantiate(spellbank.spells[spellident], transform.position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                UIShow tpz = spell.GetComponent<UIShow>();
                tpz.UI = im2;
                sd.disbleText = true;
                spelldata = sd;
                sd.time = true;


            }
        }



    }

 }
