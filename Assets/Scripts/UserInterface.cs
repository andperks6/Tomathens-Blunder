using UnityEngine;

public class UserInterface : MonoBehaviour
{
    public bool openMenu;
    public bool sub;
    public int ptab;
    public int whichTab;

    private bool wasMenuOpen;

    void Start()
    {



        openMenu = false;
        wasMenuOpen = false;

        GetComponentInChildren<Text>();
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
            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.enabled = shouldShow;
            }
            
            wasMenuOpen = shouldShow;
        }
    }

    void OnEnable()
    {
        // Ensure all sprites start hidden when enabled
        var spriteRenderers = GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.enabled = false;
        }
        openMenu = false;
        wasMenuOpen = false;
        
        Debug.Log("UserInterface: OnEnable - Reset visibility states");
    }
}
