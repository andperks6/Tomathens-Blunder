using UnityEngine;

public class UIShow : MonoBehaviour {

    public SpriteRenderer sprite;
    public InterfaceMain UI;
    public bool openMenu;
    public bool sub;
    public int ptab;
    public float whichTab;
    public bool item;
    public bool sub2;
    


    // Use this for initialization
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        Text child = GetComponentInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {

        whichTab = UI.tab;
        

        if (UI.openmenu2)
        {
            sprite.enabled = true;



        }
        if (UI.openmenu2 == false)
        {
            sprite.enabled = false;


        }
        if (sub )
        {
            if (whichTab == ptab && UI.openmenu2)
            {
                sprite.enabled = true;
            }
            else { sprite.enabled = false; }
        }
     
    }
}
