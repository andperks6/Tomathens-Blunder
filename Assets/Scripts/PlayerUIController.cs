using UnityEngine;

// Added for Action

public class PlayerUIController : MonoBehaviour
{
    private UserInterface userInterface;

    // Keep existing sprite-based UI references
    public GameObject healthBar;
    public GameObject xpBar;
    public GameObject manaPool;
    // etc. Add more references as needed

    private void Start() // Changed from Awake to Start
    {
        // Find the existing UserInterface component in children
        // Moved from Awake to Start because UserInterface(Clone) is added at runtime
        userInterface = GetComponentInChildren<UserInterface>();
        if (userInterface == null)
        {
            Debug.LogError("PlayerUIController: UserInterface component not found in children.");
        }
        else
        {
            Debug.Log("PlayerUIController: Found UserInterface component");
        }
    }

    private void OnEnable()
    {
        // Subscribe to UIManager events
        if (UIManager.Instance != null)
        {
            UIManager.Instance.OnTabMenuToggled += HandleTabMenu;
            Debug.Log("PlayerUIController: Subscribed to OnTabMenuToggled");
        }
        else
        {
            Debug.LogError("PlayerUIController: UIManager instance not found.");
        }
    }

    private void OnDisable()
    {
        // Unsubscribe from UIManager events to prevent memory leaks
        if (UIManager.Instance != null)
        {
            UIManager.Instance.OnTabMenuToggled -= HandleTabMenu;
        }
    }

    private void HandleTabMenu(bool isOpen)
    {
        Debug.Log($"PlayerUIController: HandleTabMenu called with isOpen={isOpen}");
        if (userInterface != null)
        {
            Debug.Log($"PlayerUIController: Setting userInterface.openMenu to {isOpen}");
            userInterface.openMenu = isOpen;
        }
        else
        {
            Debug.LogError("PlayerUIController: HandleTabMenu called but userInterface is null");
        }
    }

    // Add methods for managing other player UI elements as needed
}