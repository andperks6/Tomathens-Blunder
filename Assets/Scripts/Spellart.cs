using UnityEngine;

public class Spellart : MonoBehaviour
    
{
    private Animator anim;
    public int part;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("part", part);
    }
}
