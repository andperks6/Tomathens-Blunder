using UnityEngine;
using TMPro;

public class SpellData : MonoBehaviour {
    public int spellident;
    public TextMeshPro text;
    public bool disbleText;
    public bool destroy;
    public bool time;
    public bool touch;
    public float timer;
    public bool eqiuped;
    public int whichBox;
    public GameObject projectile;
    public UIShow uishow;
    public SpriteRenderer sprite;
    public bool alwayshow;
    public NetworkCharacterController cc;
    public StatManager sm;
    public float manacost;
    public string spelltype;
    public bool showring;
    public float cooldown;
    public bool startcd;
    public cooldown cd;
    public bool castable;
	// Use this for initialization
	void Start () {
        uishow = GetComponent<UIShow>();
        sprite = GetComponent<SpriteRenderer>();
        castable = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (time)
        {
            timer = timer + Time.deltaTime;
        }
        if (disbleText)
        {
            text.enabled = false;
        }
        if (destroy)
        {
            Destroy(gameObject);
        }
        if (alwayshow)
        {

            uishow.enabled = false;
            sprite.enabled = true;
        }
        if (eqiuped)
        {
            if (manacost > sm.magickaCurrent)
            {
                sprite.color = new Color(.5f, .5f, 1, 1);
            }
            else { sprite.color = new Color(1,1, 1, 1); }

            if (Input.GetKeyDown("1")&& whichBox ==1 && castable)
            {
                cc.spell = projectile;
                cc.spelltype = spelltype;
                cc.manaCost = manacost;
                cc.sd = gameObject.GetComponent<SpellData>();
                showring = true;
            }
            if (Input.GetKeyDown("2") & whichBox == 2 && castable)
            {
                cc.spell = projectile;
                cc.spelltype = spelltype;
                cc.manaCost = manacost;
                cc.sd = gameObject.GetComponent<SpellData>();
                showring = true;
            }
            if (Input.GetKeyDown("3") & whichBox == 3 && castable)
            {
                cc.spell = projectile;
                cc.spelltype = spelltype;
                cc.manaCost = manacost;
                cc.sd = gameObject.GetComponent<SpellData>();
                showring = true;
            }
            if (Input.GetKeyDown("4") & whichBox == 4 && castable)
            {
                cc.spell = projectile;
                cc.spelltype = spelltype;
                cc.manaCost = manacost;
                cc.sd = gameObject.GetComponent<SpellData>();
                showring = true;
            }
            if (Input.GetKeyDown("5") & whichBox == 5 && castable)
            {
                cc.spell = projectile;
                cc.spelltype = spelltype;
                cc.manaCost = manacost;
                cc.sd = gameObject.GetComponent<SpellData>();
                showring = true;
            }
            if (Input.GetKeyDown("6") & whichBox == 6 && castable)
            {
                cc.spell = projectile;
                cc.spelltype = spelltype;
                cc.manaCost = manacost;
                cc.sd = gameObject.GetComponent<SpellData>();
                showring = true;
            }
            if (startcd)
            {
                cd.cd = cooldown;
                cd.cd2 = cooldown;
                cd.show = true;
                startcd = false;
                castable = false;
            }


        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "spellicon")
        {
            SpellData time2 = other.gameObject.GetComponent<SpellData>();
            if (time2.timer < timer)
            {
                destroy = true;
                touch = true;
            }
        }


    }
}
