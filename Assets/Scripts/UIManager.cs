using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    // For global Canvas-based UI
    public event Action<bool> OnSystemMenuToggled;
    public event Action<bool> OnSettingsToggled;

    // For sprite-based player UI
    public event Action<bool> OnTabMenuToggled;

    private bool isSystemMenuOpen = false; // Track state
    private bool isTabMenuOpen = false; // Track state

    public void CloseSystemMenu()
    {
        isSystemMenuOpen = false;
        OnSystemMenuToggled?.Invoke(false);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Handle global UI inputs (Escape key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isSystemMenuOpen = !isSystemMenuOpen;
            OnSystemMenuToggled?.Invoke(isSystemMenuOpen);
            // Optionally, close other UI when system menu opens
            if (isSystemMenuOpen && isTabMenuOpen)
            {
                isTabMenuOpen = false;
                OnTabMenuToggled?.Invoke(isTabMenuOpen);
            }
        }

        // Handle existing tab-based UI handling
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isTabMenuOpen = !isTabMenuOpen;
            OnTabMenuToggled?.Invoke(isTabMenuOpen);
            // Optionally, close other UI when tab menu opens
            if (isTabMenuOpen && isSystemMenuOpen)
            {
                isSystemMenuOpen = false;
                OnSystemMenuToggled?.Invoke(isSystemMenuOpen);
            }
        }
    }

    // Add methods for other UI state management as needed
}