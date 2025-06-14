using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class networktest2 : NetworkBehaviour
{
    public GameObject[] races;
    
    public int boxident;
    public startbuttons sb1;
    public int whichRace;
    public NetworkConnection con2;
    public GameObject toad;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("im real");
        
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    
    public void addplayer2()
    {
        //NetworkIdentity netId = NetworkClient.connection.identity;
        Debug.Log(GetComponent<NetworkIdentity>().connectionToClient);
        Debug.Log(GetComponent<NetworkIdentity>().connectionToServer);
        ReplacePlayer(GetComponent<NetworkIdentity>().connectionToClient);


    }
    public void ReplacePlayer(NetworkConnection conn)
    {
        // Cache a reference to the current player object
        GameObject oldPlayer = conn.identity.gameObject;

        // Instantiate the new player object and broadcast to clients
        NetworkServer.ReplacePlayerForConnection(conn, Instantiate(toad, transform.position, Quaternion.Euler(0, 0, 0)));

        // Remove the previous player object that's now been replaced
        NetworkServer.Destroy(oldPlayer);
    }
}
