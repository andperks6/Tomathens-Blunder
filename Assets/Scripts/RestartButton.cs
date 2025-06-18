using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class RestartButton : MonoBehaviour
{
    private Button button;
    private NetworkManager networkManager;
    private Vector3 initialCameraPosition;

    void Start()
    {
        button = GetComponent<Button>();
        networkManager = NetworkManager.singleton;
        
        // Store initial camera position
        if (Camera.main != null)
        {
            initialCameraPosition = Camera.main.transform.position;
        }
        
        // Add click listener
        button.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        if (NetworkServer.active && NetworkClient.active) // Host mode
        {
            networkManager.StopHost();
            networkManager.StartHost();
        }
        else if (NetworkClient.active) // Client only
        {
            networkManager.StopClient();
            networkManager.StartClient();
        }
        else if (NetworkServer.active) // Server only
        {
            networkManager.StopServer();
            networkManager.StartServer();
        }

        // Reset camera to initial scene position
        if (Camera.main != null)
        {
            Camera.main.transform.position = initialCameraPosition;
        }

        // Close the system menu using UIManager
        if (UIManager.Instance != null)
        {
            UIManager.Instance.CloseSystemMenu();
        }
    }
}