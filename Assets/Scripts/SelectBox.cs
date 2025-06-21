using UnityEngine;

public class SelectBox : MonoBehaviour {
    public SpriteRenderer sprite;
    public bool show;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (show)
        {
            sprite.enabled = true;
        }
        else { sprite.enabled = false; }
	}
}
