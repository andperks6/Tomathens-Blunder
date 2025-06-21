using UnityEngine;

public class Magicbars : MonoBehaviour {
    private SpriteRenderer sprite;
    public StatManager sm;
    public InterfaceMain im;
    private Animator anim;
    public float red;
    public float green;
    public float blue;
    public float black;
    public float amount;
    public bool fire;
    public bool earth;
    public bool water;
    public bool air;
    public bool light1;
    public bool dark;
    public bool sorcery;
    public bool enchantment;
    public bool ritual;



    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
        sm = im.statmanager;
        sprite.color = new Color(red, green, blue, black);
        if (fire)
        {
            amount = sm.firelevel / 100;
        }
        if (earth)
        {
            amount = sm.earthlevel / 100;
        }
        if (water)
        {
            amount = sm.waterlevel / 100;
        }
        if (air)
        {
            amount = sm.airlevel / 100;
        }
        if (dark)
        {
            amount = sm.darklevel / 100;
        }
        if (light1)
        {
            amount = sm.lightlevel / 100;
        }
        if (sorcery)
        {
            amount = sm.sorcerylevel / 100;
        }
        if (enchantment)
        {
            amount = sm.enchantmentlevel / 100;
        }
        if (ritual)
        {
            amount = sm.rituallevel / 100;
        }


        anim.SetFloat("Blend", amount);

    }
}
