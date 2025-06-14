using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hudspells : MonoBehaviour {
    public StatManager sm;
    public Transform[] slots;
    public SplBank bank;
    public CharacterController cc;
    public SpellData spelldata1;
    public SpellData spelldata2;
    public SpellData spelldata3;
    public SpellData spelldata4;
    public SpellData spelldata5;
    public SpellData spelldata6;
    public int box1;
    public int box2;
    public int box3;
    private int box4;
    private int box5;
    private int box6;
    public int box1c;
    public int box2c;
    public int box3c;
    private int box4c;
    private int box5c;
    private int box6c;
    public bool full1;
    private bool full2;
    private bool full3;
    private bool full4;
    private bool full5;
    private bool full6;

    // Use this for initialization
    void Start () {
        bank = GetComponent<SplBank>();
        cc = sm.player;
	}
	
	// Update is called once per frame
	void Update () {
        box1c = sm.box1spell;
        box2c = sm.box2spell;
        box3c = sm.box3spell;
        box4c = sm.box4spell;
        box5c = sm.box5spell;
        box6c = sm.box6spell;
        if (box1 != box1c)
        {
            box1 = box1c;
            newspellicon(1);
        }
        if (box2 != box2c)
        {
            box2 = box2c;
            newspellicon(2);
        }
        if (box3 != box3c)
        {
            box3 = box3c;
            newspellicon(3);
        }
        if (box4 != box4c)
        {
            box4 = box4c;
            newspellicon(4);
        }
        if (box5 != box5c)
        {
            box5 = box5c;
            newspellicon(5);
        }
        if (box6 != box6c)
        {
            box6 = box6c;
            newspellicon(6);
        }




    }
    private void newspellicon(int box)
    {
        
        bank = GetComponent<SplBank>();
        if (box == 1 && box1 != 0)
        {
            if (full1 == false)
            {
                GameObject spell = (GameObject)Instantiate(bank.spells[box1], slots[0].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.disbleText = true;
                sd.time = true;
                sd.alwayshow = true;
                sd.eqiuped = true;
                sd.whichBox = 1;
                sd.cc = cc;
                sd.sm = sm;
                spelldata1 = sd;
                full1 = true;
                
            }
            if (full1 == true)
            {
                spelldata1.destroy = true;
                GameObject spell = (GameObject)Instantiate(bank.spells[box1], slots[0].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.disbleText = true;
                spelldata1 = sd;
                sd.eqiuped = true;
                sd.whichBox = 1;
                sd.time = true;
                sd.cc = cc;
                sd.sm = sm;
                sd.alwayshow = true;
            }

        }
        if (box == 2 && box2 != 0)
        {
            if (full2 == false)
            {
                GameObject spell = (GameObject)Instantiate(bank.spells[box2], slots[1].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.disbleText = true;
                sd.time = true;               
                sd.alwayshow = true;
                sd.eqiuped = true;
                sd.cc = cc;
                sd.sm = sm;
                spelldata2 = sd;
                full2 = true;
                sd.whichBox = 2;
            }
            if (full2 == true)
            {
                spelldata2.destroy = true;
                GameObject spell = (GameObject)Instantiate(bank.spells[box2], slots[1].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.disbleText = true;
                sd.eqiuped = true;
                sd.cc = cc;
                sd.sm = sm;
                spelldata2 = sd;
                sd.time = true;
                sd.alwayshow = true;
                sd.whichBox = 2;
            }
        }
        if (box == 3 && box3 != 0)
        {
            if (full3 == false)
            {
                GameObject spell = (GameObject)Instantiate(bank.spells[box3], slots[2].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.disbleText = true;
                sd.time = true;
                sd.eqiuped = true;
                sd.cc = cc;
                sd.sm = sm;
                sd.alwayshow = true;
                sd.whichBox = 3;
                spelldata3 = sd;
                full3 = true;

            }
            if (full3 == true)
            {
                spelldata3.destroy = true;
                GameObject spell = (GameObject)Instantiate(bank.spells[box3], slots[2].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.disbleText = true;
                sd.eqiuped = true;
                sd.cc = cc;
                sd.sm = sm;
                sd.whichBox = 3;
                spelldata3 = sd;
                sd.time = true;
                sd.alwayshow = true;
            }
        }
        if (box == 4 && box4 != 0)
        {
            if (full4 == false)
            {
                GameObject spell = (GameObject)Instantiate(bank.spells[box4], slots[3].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.disbleText = true;
                sd.eqiuped = true;
                sd.cc = cc;
                sd.sm = sm;
                sd.whichBox = 4;
                sd.time = true;
                spelldata4 = sd;
                sd.alwayshow = true;
                full4 = true;
            }
            if (full4 == true)
            {
                spelldata4.destroy = true;
                GameObject spell = (GameObject)Instantiate(bank.spells[box4], slots[3].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.eqiuped = true;
                sd.cc = cc;
                sd.sm = sm;
                sd.disbleText = true;
                sd.whichBox = 4;
                spelldata4 = sd;
                sd.time = true;
                sd.alwayshow = true;
            }
        }
        if (box == 5 && box5 != 0)
        {
            if (full5 == false)
            {
                GameObject spell = (GameObject)Instantiate(bank.spells[box5], slots[4].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.disbleText = true;
                sd.time = true;
                sd.eqiuped = true;
                sd.cc = cc;
                sd.sm = sm;
                sd.whichBox = 5;
                spelldata5 = sd;
                sd.alwayshow = true;
                full5 = true;
            }
            if (full5 == true)
            {
                spelldata5.destroy = true;
                GameObject spell = (GameObject)Instantiate(bank.spells[box5], slots[4].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.disbleText = true;
                sd.eqiuped = true;
                sd.cc = cc;
                sd.sm = sm;
                sd.whichBox = 5;
                sd.time = true;
                spelldata5 = sd;
                sd.alwayshow = true;
            }
        }
        if (box == 6 && box6 != 0)
        {
            if (full6 == false)
            {
                GameObject spell = (GameObject)Instantiate(bank.spells[box6], slots[5].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.disbleText = true;
                sd.time = true;
                sd.eqiuped = true;
                sd.cc = cc;
                sd.sm = sm;
                sd.whichBox = 6;
                spelldata6 = sd;
                sd.alwayshow = true;
                full6 = true;
            }
            if (full6 == true)
            {
                spelldata6.destroy = true;
                GameObject spell = (GameObject)Instantiate(bank.spells[box6], slots[5].position, Quaternion.Euler(0, 0, 0));
                spell.transform.parent = transform;
                SpellData sd = spell.GetComponent<SpellData>();
                sd.disbleText = true;
                sd.whichBox = 6;
                sd.eqiuped = true;
                sd.cc = cc;
                sd.sm = sm;
                sd.time = true;
                spelldata6 = sd;
                sd.alwayshow = true;
            }
        }
    }
}
