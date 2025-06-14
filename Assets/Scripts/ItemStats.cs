using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStats : MonoBehaviour {
    
    public float strength;
    public float wisdom;
    public float speed;
    public float damage;
    public float health;
    public float movespeed;
    public float magicka;
    public float magickaRegen;
    public float healthRegen;
    public float haste;
    public float sprintregen;


    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    public void updatestats()
    {
        StatManager stat = GetComponentInParent<StatManager>();
        stat.strength = stat.strength + strength;
        stat.wisdom = stat.wisdom + wisdom;
        stat.speed = stat.speed + speed;
        stat.damage1 = stat.damage1 + damage;
        stat.health1 = stat.health1 + health;
        stat.movespeed1 = stat.movespeed1 + movespeed;
        stat.magicka1 = stat.magicka1 + magicka;
        stat.magickaRegen1 = stat.magickaRegen1 + magickaRegen;
        stat.healthRegen1 = stat.healthRegen1 + healthRegen;
        stat.sprintregen1 = stat.sprintregen1 + sprintregen;
        stat.GetComponentInParent<StatManager>().updateStat();
    }
    public void uneqiuped()
    {
        StatManager stat = GetComponentInParent<StatManager>();
        stat.strength = stat.strength - strength;
        stat.wisdom = stat.wisdom - wisdom;
        stat.speed = stat.speed - speed;
        stat.damage1 = stat.damage1 - damage;
        stat.health1 = stat.health1 - health;
        stat.movespeed1 = stat.movespeed1 - movespeed;
        stat.magicka1 = stat.magicka1 - magicka;
        stat.magickaRegen1 = stat.magickaRegen1 - magickaRegen;
        stat.healthRegen1 = stat.healthRegen1- healthRegen;
        stat.sprintregen1 = stat.sprintregen1 - sprintregen;
        stat.GetComponentInParent<StatManager>().updateStat();
    }
}
