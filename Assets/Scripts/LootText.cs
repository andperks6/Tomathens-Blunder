using UnityEngine;
using TMPro;

public class LootText : MonoBehaviour {


    private TextMeshPro text1;
    public float number;
    private bool openMenu;
    public bool decorative;
    public bool showing;



    // Use this for initialization
    void Start()
    {
        text1 = GetComponent<TextMeshPro>();
        number = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (decorative == false)
        {
            text1.text = number.ToString();
        }
       
    }
}
