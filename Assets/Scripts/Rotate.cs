using UnityEngine;

public class Rotate : MonoBehaviour {
    private float rotatenumber;

	// Use this for initialization
	void Start () {
        rotatenumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
        rotatenumber = rotatenumber - 1;
        transform.Rotate(0,0,rotatenumber);

    }
}
