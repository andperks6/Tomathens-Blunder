using UnityEngine;

public class SpellButtons : MonoBehaviour {

    public bool size;
    public Spells sp;
    public SpellData spelldata;
    public int whichspell;
    public SpriteRenderer sprite;
    private float colorChange;
    public int box;
    private bool startTime;
    public float timer;
    public bool selected;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (size == false)
        {
            transform.localScale = new Vector3(1f, 1f, 1);
        }
        if (size)
        {
            transform.localScale = new Vector3(1.03f, 1.03f, 1);
            size = false;
        }
        if (colorChange > 0)
        {
            colorChange = colorChange - Time.deltaTime;
        }
        else { sprite.color = new Color(1f, 1f, 1f, 1); }
        
         whichspell = sp.spellint[box];
       
        if (whichspell != sp.whichspell2)
        {
            selected = false;
            sp.selected = selected;
            
        }



    }
    public void OnMouseOver()
    { if (whichspell != 0)
        {
            size = true;
        }
        
    }
    public void OnMouseDown()
    {
        if (gameObject.tag == "Close")
        {
            
            sprite.color = new Color(.5f, .5f, .5f, 1);
            colorChange = .2f;
            whichspell = 0;
            sp.destroy1();
            
        }
        if (gameObject.tag == "Spelltab" && whichspell != 0 && selected == false)
        {
            sp.whichspell2 = whichspell;
            sp.whichbox = box;
            sp.spellset = true;
           
            selected = true;
        }


    }
}
