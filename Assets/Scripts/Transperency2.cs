using UnityEngine;

public class Transperency2 : MonoBehaviour {

	
        SpriteRenderer sprite;
        public float amount;

        // Use this for initialization
        void Start()
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.color = new Color(1, 1, 1, amount);
        }

        // Update is called once per frame
        void Update()
        {

        }
    
}
