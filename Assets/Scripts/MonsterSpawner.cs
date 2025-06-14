using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {
    public GameObject cricketmage, cricketwarrior, beetlewarrior;
    public Vector3 spawnpoint1, spawnpoint2, spawnpoint3;
    private bool spawned;
    // Use this for initialization
    void Start () {
        GameObject monster = (GameObject)Instantiate(cricketmage,spawnpoint1, Quaternion.Euler(0, 0, 0));
        GameObject monster2 = (GameObject)Instantiate(cricketwarrior, spawnpoint2, Quaternion.Euler(0, 0, 0));
        GameObject monster3 = (GameObject)Instantiate(beetlewarrior, spawnpoint3, Quaternion.Euler(0, 0, 0));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
