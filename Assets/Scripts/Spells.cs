using UnityEngine;

public class Spells : MonoBehaviour {
    public GameObject[] spellslots;
    public GameObject[] spells;
    public int[] spellint;
    public bool open;
    public SpriteRenderer sprite;
    public bool spawn;
    private Vector3 vector;
    public int whichspell2;
    public int whichbox;
    public InterfaceMain im;
    public bool spellset;
    public bool selected;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        vector = new Vector3(10, -10);
        spellset = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (spellset)
        {
            im.whichspell = whichspell2;
            im.spellring = true;
        }
       

    }
    public void destroy1()
    {
        
        im.spellring = false;
        Destroy(gameObject);
        
    }
    public void spawn1()
    {
        GameObject spell1 = Instantiate(spells[spellint[0]], new Vector3(spellslots[0].transform.position.x -.625f, spellslots[0].transform.position.y+.575f), Quaternion.Euler(0, 0, 0));
        spell1.transform.parent = transform;
        UIShow ui1 = spell1.GetComponent<UIShow>();
        ui1.UI = im;
        GameObject spell2 = Instantiate(spells[spellint[1]], new Vector3(spellslots[1].transform.position.x - .625f, spellslots[0].transform.position.y + .575f), Quaternion.Euler(0, 0, 0));
        spell2.transform.parent = transform;
        UIShow ui2 = spell2.GetComponent<UIShow>();
        ui2.UI = im;
        GameObject spell3 = Instantiate(spells[spellint[2]], new Vector3(spellslots[2].transform.position.x - .625f, spellslots[0].transform.position.y + .575f), Quaternion.Euler(0, 0, 0));
        spell3.transform.parent = transform;
        UIShow ui3 = spell3.GetComponent<UIShow>();
        ui3.UI = im;
        GameObject spell4 = Instantiate(spells[spellint[3]], new Vector3(spellslots[3].transform.position.x - .625f, spellslots[0].transform.position.y + .575f), Quaternion.Euler(0, 0, 0));
        spell4.transform.parent = transform;
        UIShow ui4 = spell4.GetComponent<UIShow>();
        ui4.UI = im;
        GameObject spell5 = Instantiate(spells[spellint[4]], new Vector3(spellslots[4].transform.position.x - .625f, spellslots[0].transform.position.y + .575f), Quaternion.Euler(0, 0, 0));
        spell5.transform.parent = transform;
        UIShow ui5 = spell5.GetComponent<UIShow>();
        ui5.UI = im;
        GameObject spell6 = Instantiate(spells[spellint[5]], new Vector3(spellslots[5].transform.position.x - .625f, spellslots[0].transform.position.y + .575f), Quaternion.Euler(0, 0, 0));
        spell6.transform.parent = transform;
        UIShow ui6 = spell6.GetComponent<UIShow>();
        ui6.UI = im;
    }
    
}
