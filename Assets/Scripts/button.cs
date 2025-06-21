using UnityEngine;

public class button : MonoBehaviour
{
    public bool size;
    public int tab;
    public UserInterface parent;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (parent == null)
        {
            Debug.LogError("Button script: Parent UserInterface not assigned!");
        }
    }

    void Update()
    {
        if (parent != null)
        {
            // Handle hover scale effect
            if (size == false)
            {
                transform.localScale = new Vector3(1f, 1f, 1);
            }
            if (size)
            {
                transform.localScale = new Vector3(1.05f, 1.05f, 1);
                size = false;
            }

            // Update tab state
            tab = parent.ptab;

            // Handle animation
            if (anim != null)
            {
                anim.SetInteger("Tab", tab);
            }
            else
            {
                anim = GetComponent<Animator>();
            }
        }
    }

    public void OnMouseOver()
    {
        // Only scale if the parent menu is open
        if (parent != null && parent.openMenu)
        {
            size = true;
        }
    }

    public void OnMouseDown()
    {
        // Only process click if the parent menu is open
        if (parent != null && parent.openMenu)
        {
            int selectedTab = parent.ptab; // Default to current ptab

            if (tag == "Overview")
            {
                selectedTab = 1;
            }
            else if (tag == "Magic")
            {
                selectedTab = 2;
            }
            else if (tag == "Misc")
            {
                selectedTab = 3;
            }
            else if (tag == "Settings")
            {
                selectedTab = 4;
            }

            // Update the parent's tab state
            parent.ptab = selectedTab;
            parent.whichTab = selectedTab;

            // Update animator
            if (anim != null)
            {
                anim.SetInteger("Tab", selectedTab);
            }
        }
    }
}
