using UnityEngine;
using Mirror;

public class networktest : NetworkManager


{

    public GameObject[] races;    
    public int boxident;
    public Transform startpos;
    private NetworkConnection conn1;
    private bool phase1;
    private bool phase2;
    public networktest2 nw2;
    public int whichRace;
    public GameObject toad;

    // Start is called before the first frame update

  

    // Update is called once per frame
    void Update()
    {
        

            
        //playerPrefab = races[whichRace];
        
     

    }
    
  //  public override void OnClientConnect(NetworkConnection conn)
  //  {
        
    //    Debug.Log("soomeone has joined");
        //OnServerAddPlayer(conn);



   // }
    

  //  public override void OnServerAddPlayer(NetworkConnection conn)
  // {
   //     Debug.Log("12412");
   //     GameObject player = Instantiate(playerPrefab, startpos.position, Quaternion.Euler(0, 0, 0));
    //    NetworkServer.AddPlayerForConnection(conn, player);
        
                    
 //  }
    
    

    public void ReplacePlayer(NetworkConnection conn)
    {
        // Cache a reference to the current player object
       GameObject oldPlayer = conn.identity.gameObject;

        // Instantiate the new player object and broadcast to clients
      NetworkServer.ReplacePlayerForConnection(conn, Instantiate(toad,transform.position, Quaternion.Euler(0, 0, 0)));

        // Remove the previous player object that's now been replaced
        NetworkServer.Destroy(oldPlayer);
    }
    
    
}
