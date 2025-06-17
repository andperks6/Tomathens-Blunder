using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {


    public bool size;
    private Vector3 size1;
    public ItemType itemType = ItemType.Normal;
    public string type;
    public int whichselect;
    public bool selected;
    public bool selectBoxes;
    public bool SBS;
    public int SBSI;
    public int whichSelectBox;
    public InterfaceMain IM;
    public SpriteRenderer sprite;
    public BoxCollider2D box2d;
    public int ws;
    public bool openMenu;
    public Vector2 itemPos;
    public bool equiped;
    private bool boxfilled;
    public GameObject iteminslot;
    public ItemStats stats;
    public GameObject box;
    public GameObject spellbook;
    public ShopText description;
    public string content1;
    private bool showingbox;
    public float tab1;
    public float tab;
    public int[] whichSpell;

    // Convert equipment type string to slot selection
    // This handles equipment slots (head, foot, chest) separately from ItemType (Normal, Spell, Key)
    private void SetEquipmentType(string typeStr) {
        switch(typeStr.ToLower()) {
            case "misc":
                whichselect = 1;
                break;
            case "head":
                whichselect = 2;
                break;
            case "foot":
                whichselect = 3;
                break;
            case "chest":
                whichselect = 4;
                break;
        }
    }
    
    


    // Use this for initialization
    void Start()
    {
        size1 = new Vector3(transform.localScale.x, transform.localScale.y);
        sprite = GetComponent<SpriteRenderer>();
        box2d = GetComponent<BoxCollider2D>();
        stats = GetComponent<ItemStats>();
        sprite.enabled = false;

        // Initialize equipment slot based on type
        if (!string.IsNullOrEmpty(type)) {
            SetEquipmentType(type);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ws = IM.whichSelect;
        tab1 = IM.tab;

       
        if (Input.GetKeyDown("tab"))
        {
            openMenu = !openMenu;

        }
        if (openMenu == true && tab == tab1)
        {
            if (selectBoxes == false)
            { sprite.enabled = true; }
                if (IM.sbShow == true)
            {
                SBS = true;
            }
            else { SBS = false; }
           

            if (size == false)
            {
                transform.localScale = new Vector3(size1.x, size1.y, 1);
            }
            if (size == true)
            {
                transform.localScale = new Vector3(size1.x + .05f, size1.y + .05f, 1);
                size = false;
            }
            if (itemType != ItemType.Spell)
            {
                if (SBSI == ws && selectBoxes == true && SBS == true)
                {
                    sprite.enabled = true;
                }
                if (SBSI != ws && selectBoxes == true)
                {
                    sprite.enabled = false;
                }
                if (SBS == false && selectBoxes == true)
                {
                    sprite.enabled = false;
                }
            }
        }
        else { sprite.enabled = false; }
        
    }
    public void OnMouseOver()
    {
        if (selectBoxes == false && itemType != ItemType.Spell)
        {
            size = true;
            
            description.showing = true;
            description.content = content1;
            if (showingbox == false)
            { 
            Vector2 spot = new Vector2(transform.position.x + 1.4f, transform.position.y+.3f);
            GameObject textbox = (GameObject)Instantiate(box, spot, Quaternion.Euler(0, 0, 0));
            textbox.transform.SetParent(transform, false);
            showingbox = true;
            }
           
        }
        if (selectBoxes == false && itemType == ItemType.Spell)
        {
            size = true;

        }
        if (selectBoxes == true)
        {
            size = true;
            
        }

    }
    public void OnMouseDown()
    {
        if (itemType != ItemType.Spell)
        {
            if (selectBoxes == false && equiped == false)
            {
                selected = true;
                itemPos = transform.position;
                IM.GetComponent<InterfaceMain>().selectBox(itemPos);
                IM.item = gameObject;
                IM.GetComponent<InterfaceMain>().showboxes(whichselect);
            }
            if (selectBoxes == true && SBSI == ws && boxfilled == false)
            {

                IM.GetComponent<InterfaceMain>().itemTransfer(whichSelectBox);
                boxfilled = true;
            }
            if (selectBoxes == true && SBSI == ws && boxfilled == true && iteminslot != null)
            {
                iteminslot.transform.position = IM.item.transform.position;
                InventoryItem i = iteminslot.GetComponent<InventoryItem>();
                if (i != null)
                {
                    i.box2d.enabled = true;
                    i.GetComponent<ItemStats>().uneqiuped();
                    i.equiped = false;
                    i.stats.enabled = false;
                }

                IM.GetComponent<InterfaceMain>().itemTransfer(whichSelectBox);
            }
        }
        if (selectBoxes == false && itemType == ItemType.Spell)
        {
            size = true;
            Vector2 spot2 = new Vector2(IM.spotforsw.position.x, IM.spotforsw.position.y);
            GameObject spellwindow = (GameObject)Instantiate(spellbook, spot2, Quaternion.Euler(0, 0, 0));
           
            Spells ss = spellwindow.GetComponent<Spells>();
            ss.im = IM;
            ss.spellint[0] = whichSpell[0];
            ss.spellint[1] = whichSpell[1];
            ss.spellint[2] = whichSpell[2];
            ss.spellint[3] = whichSpell[3];
            ss.spellint[4] = whichSpell[4];
            ss.spellint[5] = whichSpell[5];
            ss.spawn1();
           
        }

    }
    public void OnMouseExit()
    {
        if (itemType != ItemType.Spell)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            showingbox = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Item")
        {
            iteminslot = other.gameObject;
            InventoryItem i = iteminslot.GetComponent<InventoryItem>();
            i.box2d.enabled = false;
        }
    }
   

}
