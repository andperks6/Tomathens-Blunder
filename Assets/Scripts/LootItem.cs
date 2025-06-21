using UnityEngine;

public class LootItem : MonoBehaviour {
    public bool currency;
    private bool size;
    public float amount;
    public LootText text1;
    public bool hasText;
    private Vector3 sizeofart;
    public string ItemType;
    public StatManager sm;

	// Use this for initialization
	void Start () {
        sizeofart = new Vector3(transform.localScale.x, transform.localScale.y);
	}
	
	// Update is called once per frame
	void Update () {

        if (hasText)
        {
            LootText t = text1.GetComponent<LootText>();
            t.number = amount;
        }
        
        if (size == false)
        {
            transform.localScale = sizeofart;
        }
        if (size)
        {
            transform.localScale = new Vector3(sizeofart.x + .05f, sizeofart.y + .05f, 1);
            size = false;
        }
    }
    public void OnMouseOver()
    {
        size = true;
    }
    public void OnMouseDown()
    {
        if (ItemType == "Gold")
        {
           //StatManager bag = FindObjectOfType<StatManager>().updateBag(amount);
           
            sm.gold =+ sm.gold + amount;
            Destroy(gameObject);
        }
        if (ItemType == "Garnet")
        {
            StatManager bag = FindObjectOfType<StatManager>();
            bag.garnet = bag.garnet + amount;
            Destroy(gameObject);
        }
        if (ItemType == "Ruby")
        {
            StatManager bag = FindObjectOfType<StatManager>();
            bag.ruby = bag.garnet + amount;
            Destroy(gameObject);
        }
    }
}
