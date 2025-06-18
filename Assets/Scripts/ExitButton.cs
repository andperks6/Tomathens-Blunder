using UnityEngine;
using UnityEngine.UI;
using Mirror;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ExitButton : MonoBehaviour
{
    private Button button;
    private NetworkManager networkManager;

    void Start()
    {
        button = GetComponent<Button>();
        networkManager = NetworkManager.singleton;
        
        // Add click listener
        button.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        // First handle network disconnection if needed
        if (NetworkServer.active && NetworkClient.active) // Host mode
        {
            networkManager.StopHost();
        }
        else if (NetworkClient.active) // Client only
        {
            networkManager.StopClient();
        }
        else if (NetworkServer.active) // Server only
        {
            networkManager.StopServer();
        }

        // Close the system menu using UIManager
        if (UIManager.Instance != null)
        {
            UIManager.Instance.CloseSystemMenu();
        }

        Debug.Log("Exiting game...");

#if UNITY_EDITOR
        // If running in the Unity editor, stop playing
        EditorApplication.isPlaying = false;
#else
        // If running in a build, quit the application
        Application.Quit();
#endif
    }
}