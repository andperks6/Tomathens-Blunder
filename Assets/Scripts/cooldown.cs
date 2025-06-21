using UnityEngine;

public class cooldown : MonoBehaviour {
    public SpellData sd;
    public SpriteRenderer sprite;
    private Animator anim;
    public float cd;
    public float cd2;
    public float cdpercent;
    public bool show;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (show)
        {
            sprite.enabled = true;
            cd = cd - Time.deltaTime;
            cdpercent = cd / cd2;
            cdpercent = 1 - cdpercent;
            anim.SetFloat("cooldowntime",cdpercent);
            if (cd < 0)
            {
                show = false;
                sd.castable = true;
            }
        }
		else { sprite.enabled = false; }


	}
}
