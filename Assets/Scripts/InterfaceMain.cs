
using System.Collections.Generic;
using UnityEngine;

public class InterfaceMain : MonoBehaviour {
    public UserInterface parent;
    public Animator anim;
    public StatManager statmanager;
    public float tab;
    public Transform[] Invslots;
    public Transform[] spellslots;
    public Transform[] loadoutSlots;
    public Transform[] KeySlots;
    public GameObject[] GameItems;
    public GameObject[] Keys;
    public GameObject[] selectBoxes;
    private int slotsUsed;
    private int spellslotsused;
    public bool sbShow;
    public int whichSelect;
    public GameObject select;
    public bool disableSelect;
    private float disableselectTimer;
    public GameObject item;
    public Transform spotforsw;
    public int whichspell;
    public bool spellring;
    public int box1spell;
    public int box2spell;
    public int box3spell;
    public int box4spell;
    public int box5spell;
    public int box6spell;
    public bool check;
    public bool openmenu2;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        slotsUsed = 0;
        whichSelect = 0;
        SpriteRenderer sprite = select.GetComponentInChildren<SpriteRenderer>();
        sprite.sortingOrder = 0;
        disableselectTimer = .1f;
    }

    // Update is called once per frame
    void Update() {
        tab = parent.ptab;
        openmenu2 = parent.openMenu;
        anim.SetFloat("Tab", tab);
        if (disableSelect == true)
        {
            disableselectTimer = disableselectTimer - Time.deltaTime;
            if (disableselectTimer < 0)
            {
                disableSelect = false;
                disableselectTimer = .1f;
            }
        }
        StatManager spells = GetComponentInParent<StatManager>();
        spells.box1spell = box1spell;
        spells.box2spell = box2spell;
        spells.box3spell = box3spell;
        spells.box4spell = box4spell;
        spells.box5spell = box5spell;
        spells.box6spell = box6spell;


    }
    public void NewItem(int ID, bool spell)
    {
        if (spell == false) {
            GameObject item = (GameObject)Instantiate(GameItems[ID], Invslots[slotsUsed].position, Quaternion.Euler(0, 0, 0));
            item.transform.parent = transform;
            slotsUsed++;
            InventoryItem II = item.GetComponent<InventoryItem>();
            II.IM = gameObject.GetComponent<InterfaceMain>();
        }
        if (spell == true)
        {
            GameObject item = (GameObject)Instantiate(GameItems[ID], spellslots[spellslotsused].position, Quaternion.Euler(0, 0, 0));
            item.transform.parent = transform;
            spellslotsused++;
            InventoryItem II = item.GetComponent<InventoryItem>();
            II.IM = gameObject.GetComponent<InterfaceMain>();
        }

    }
    public void NewKey(int ID)
    {
        GameObject item = (GameObject)Instantiate(Keys[ID - 1], KeySlots[ID - 1].position, Quaternion.Euler(0, 0, 0));
        item.transform.parent = transform;
        UIShow kid = item.GetComponent<UIShow>();
        kid.UI = gameObject.GetComponent<InterfaceMain>();



    }
    public void showboxes(int wsi)
    {
        sbShow = true;
        whichSelect = wsi;
    }
    public void selectBox(Vector2 moonman)
    {
        SpriteRenderer sprite = select.GetComponentInChildren<SpriteRenderer>();
        sprite.sortingOrder = 202;
        select.transform.position = moonman;
    }
    public void disable()
    {
        disableSelect = true;
    }
    public void itemTransfer(int whichSelectBox)
    {
        item.transform.position = loadoutSlots[whichSelectBox].position;
        InventoryItem eq = item.GetComponent<InventoryItem>();
        eq.equiped = true;
        eq.stats.updatestats();
        item = null;

    }
    public void updatespells()
    {
        

    }

}
