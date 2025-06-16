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
    startbuttons whichRaceObj;
    public NetworkConnection con2;
    public GameObject toad;
    //TODO: validate best start position. took base value from playerstart pos game object
	  public Vector3 playerSpawnPosition = new Vector3(127.93f, -57.8f, 0);
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

        // Instantiate the new player object based on the selected race and broadcast to clients
        // Ensure whichRace is a valid index for the races array
        GameObject playerPrefabToSpawn = toad; // Default to toad
        if (races != null && whichRace >= 0 && whichRace < races.Length && races[whichRace] != null)
        {
            playerPrefabToSpawn = races[whichRace];
        }
        else
        {
            Debug.LogError($"Invalid race index ({whichRace}) or races array not set. Spawning default toad prefab.");
        }

        NetworkServer.ReplacePlayerForConnection(conn, Instantiate(playerPrefabToSpawn, transform.position, Quaternion.Euler(0, 0, 0)));

        // Remove the previous player object that's now been replaced
        NetworkServer.Destroy(oldPlayer);
    }

    public void ShowSelectedChar(startbuttons character)
    {
        if (whichRaceObj)
        {
            whichRaceObj.GetComponent<SpriteRenderer>().color = Color.white;
        }
        whichRaceObj = character;
        character.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
