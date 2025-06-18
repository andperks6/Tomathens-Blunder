using UnityEngine;
using System; // Added for Action

public class GlobalUIController : MonoBehaviour
{
    public Canvas systemMenuCanvas;
    public Canvas settingsCanvas;
    // etc. Add more global UI elements as needed

    private void Start()
    {
        // Ensure all canvases are disabled by default
        if (systemMenuCanvas != null)
        {
            systemMenuCanvas.enabled = false;
        }
        if (settingsCanvas != null)
        {
            settingsCanvas.enabled = false;
        }
    }

    private void OnEnable()
    {
        // Subscribe to UIManager events
        if (UIManager.Instance != null)
        {
            UIManager.Instance.OnSystemMenuToggled += HandleSystemMenu;
            UIManager.Instance.OnSettingsToggled += HandleSettingsMenu; // Added for settings
        }
        else
        {
            Debug.LogError("GlobalUIController: UIManager instance not found.");
        }
    }

    private void OnDisable()
    {
        // Unsubscribe from UIManager events to prevent memory leaks
        if (UIManager.Instance != null)
        {
            UIManager.Instance.OnSystemMenuToggled -= HandleSystemMenu;
            UIManager.Instance.OnSettingsToggled -= HandleSettingsMenu; // Added for settings
        }
    }

    private void HandleSystemMenu(bool isOpen)
    {
        if (systemMenuCanvas != null)
        {
            systemMenuCanvas.enabled = isOpen;
        }
    }

    private void HandleSettingsMenu(bool isOpen) // Added for settings
    {
        if (settingsCanvas != null)
        {
            settingsCanvas.enabled = isOpen;
        }
    }

    // Add methods for managing other global UI visibility, etc. later
}