using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {
    public string parent;
    public bool show;
    public GameObject[] items;
    public Transform[] slots;
    private int boxes;
    private bool spawned;
    public StatManager sm;

    public float random;
    

	// Use this for initialization
	void Start () {
        show = true;
        boxes = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //you still need to decide what loot each enemy gives when you kill it exept for crickets warrior
        string parentname = transform.parent.tag;
        parent = parentname;
        if(parent == "Cricket" && spawned == false)
        {
            GameObject gold = (GameObject)Instantiate(items[0], slots[0].position, Quaternion.Euler(0, 0, 0));
            gold.transform.parent = gameObject.transform;
            LootItem stat = gold.GetComponent<LootItem>();
            stat.sm = sm;          
            stat.amount = Random.Range(3,7);
            random = Random.Range(1,3);
           
            if (random == 1)
            {
                GameObject garnet= (GameObject)Instantiate(items[1], slots[1].position, Quaternion.Euler(0, 0, 0));
                garnet.transform.parent = gameObject.transform;                              
                LootItem stat1 = garnet.GetComponent<LootItem>();
                stat1.sm = sm;
                stat1.amount = 1;
            }
            spawned = true;

        }
        if (parent == "Beetle" && spawned == false)
        {
            GameObject gold1 = (GameObject)Instantiate(items[0], slots[0].position, Quaternion.Euler(0, 0, 0));
            gold1.transform.parent = gameObject.transform;
            LootItem stat = gold1.GetComponent<LootItem>();
            stat.sm = sm;
            stat.amount = Random.Range(8, 13);
            random = Random.Range(1, 3);
            
            if (random == 1)
            {
                GameObject ruby = (GameObject)Instantiate(items[4], slots[1].position, Quaternion.Euler(0, 0, 0));
                ruby.transform.parent = gameObject.transform;
                LootItem stat1 = ruby.GetComponent<LootItem>();
                stat1.sm = sm;
                stat1.amount = 1;
               
            }
            spawned = true;
        }
        

        if (show == false)
        {
            Destroy(gameObject);
        }
	}
}
