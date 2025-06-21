using UnityEngine;

public class Bobo : MonoBehaviour {
    public SpellButtons sp1;
    public SpriteRenderer sprite;
    public SpellData spelldata;
    public bool equip;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        if (equip == false)
        {
            if (sp1.selected)
            {
                sprite.enabled = true;
            }
            else { sprite.enabled = false; }

        }
        if (equip)
        {
            if (spelldata.showring)
            {
                sprite.enabled = true;
            }
            else { sprite.enabled = false; }

        }
    }
}
