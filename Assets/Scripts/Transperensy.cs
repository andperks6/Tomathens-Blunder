using UnityEngine;

public class Transperensy : MonoBehaviour {
    SpriteRenderer sprite; 
    
    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1, 1, 1, .5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
