using UnityEngine;

public class startbuttons : MonoBehaviour
{
    public startscreen nw;
    public int boxident;
    private bool size;
    private Vector3 v3;
    public networktest network;
    public networktest2 parent;

    [SerializeField]
    GameObject highlightObject;


    [SerializeField]
    bool startSelected;

    Vector3 startScale;
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
        if (startSelected)
        {
            parent.ShowSelectedChar(this);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (size == false)
        {
            transform.localScale = startScale;
        }
        if (size)
        {
            transform.localScale = startScale * 1.2f;
            size = false;
        }
        }
        public void OnMouseOver()
        {
            size = true;
        }

        public void OnMouseDown()
        {
        if (gameObject.tag == "PlayerIcon")
        {

            parent.whichRace = boxident;
            parent.ShowSelectedChar(this);

        }
        // TODO: add switching teams functionality
        //  if (gameObject.tag == "Next")
        //   {
        //             
        //   }
        if (gameObject.tag == "Start")
        {
            parent.addplayer2();

        }
        if (gameObject.tag == "Sell")
        {

        }
    }

}
