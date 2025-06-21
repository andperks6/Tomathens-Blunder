using UnityEngine;

public class Textmenu : MonoBehaviour {

    public GameObject[] textboxes;
    public Transform[] loudout;
    public float goldAmount;
    public float rubyAmount;
    public float emeraldAmount;
    public float garnetAmount;
    public float diamondAmount;
    public float StrengthAmount;
    public float wisdomAmount;
    public float speedAmount;
    public float damageAmount;
    public float healthAmount;
    public float movementAmount;
    public float armorAmount;
    public float hasteAmount;
    public float magickaregenAmount;
    public float healthregenAmount;
    public float sprintregenAmount;
    public float speechAmount;
    public float fortitudeAmount;
    public float aptitudeAmount;
    public float carryAmount;
    public float magickaAmount;
    public float luckAmount;
    public float magicresAmount;
    public bool test;


    // Use this for initialization
    void Start () {

      
    }
	
	// Update is called once per frame
	void Update () {
       

        Text Strength = textboxes[5].GetComponent<Text>();
        Text wisdom = textboxes[6].GetComponent<Text>();
        Text speed = textboxes[7].GetComponent<Text>();
        Text damage = textboxes[8].GetComponent<Text>();
        Text health = textboxes[9].GetComponent<Text>();
        Text movement = textboxes[10].GetComponent<Text>();
        Text armor = textboxes[11].GetComponent<Text>();
        Text haste = textboxes[12].GetComponent<Text>();
        Text magregen = textboxes[13].GetComponent<Text>();
        Text helregen = textboxes[14].GetComponent<Text>();
        Text sprintregen = textboxes[15].GetComponent<Text>();
        Text luck = textboxes[16].GetComponent<Text>();
        Text speech = textboxes[17].GetComponent<Text>();
        Text fortitude = textboxes[18].GetComponent<Text>();
        Text aptitude = textboxes[19].GetComponent<Text>();
        Text carry = textboxes[20].GetComponent<Text>();
        Text magicka = textboxes[21].GetComponent<Text>();
        Text magicres = textboxes[22].GetComponent<Text>();
        Strength.number = StrengthAmount;
        wisdom.number = wisdomAmount;
        speed.number = speedAmount;
        damage.number = damageAmount;
        health.number = healthAmount;
        movement.number = movementAmount;
        armor.number = armorAmount;
        haste.number = hasteAmount;
        magregen.number = magickaregenAmount;
        helregen.number = healthregenAmount;
        sprintregen.number = sprintregenAmount;
        luck.number = luckAmount;
        speech.number = speechAmount;
        fortitude.number = fortitudeAmount;
        aptitude.number = aptitudeAmount;
        carry.number = carryAmount;
        magicka.number = magickaAmount;
        magicres.number = magicresAmount;

        Text gold = textboxes[0].GetComponent<Text>();
        Text ruby = textboxes[1].GetComponent<Text>();
        Text emerald = textboxes[2].GetComponent<Text>();
        Text garent = textboxes[3].GetComponent<Text>();
        Text diamond = textboxes[4].GetComponent<Text>();
        gold.number = goldAmount;
        ruby.number = rubyAmount;
        emerald.number = emeraldAmount;
        garent.number = garnetAmount;
        diamond.number = diamondAmount;

    }
   



}
