using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    Transform camera;
    public bool openMenu;
    public bool sub;
    public int ptab;
    public int whichTab;

    private bool wasMenuOpen;

    void Start()
    {



        openMenu = false;
        wasMenuOpen = false;

        Text child = GetComponentInChildren<Text>();
        ptab = 1;
        whichTab = 1;
        
    }

    void Update()
    {
        bool shouldShow = openMenu;
        if (openMenu && sub && whichTab != ptab)
        {
            shouldShow = false;
        }

        // Only update visibility if menu state changed
        if (wasMenuOpen != shouldShow)
        {
            Debug.Log($"UserInterface: Menu state changed - shouldShow: {shouldShow}, previous: {wasMenuOpen}");
            
            // Update all sprite renderers visibility
            var spriteRenderers = GetComponentsInChildren<SpriteRenderer>(true);
            foreach (var renderer in spriteRenderers)
            {
                renderer.enabled = shouldShow;
            }
            
            wasMenuOpen = shouldShow;
        }
    }

    void OnEnable()
    {
        // Ensure all sprites start hidden when enabled
        var spriteRenderers = GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var renderer in spriteRenderers)
        {
            renderer.enabled = false;
        }
        openMenu = false;
        wasMenuOpen = false;
        
        Debug.Log("UserInterface: OnEnable - Reset visibility states");
    }
}
