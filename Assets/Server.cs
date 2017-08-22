using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;

public class Server : MonoBehaviour {

    bool IsHeadless() { return SystemInfo.graphicsDeviceType == GraphicsDeviceType.Null; }


    NetworkClient myClient;
    public bool isConnected{ get { return _connected; } } 
    bool _connected { get; set;} 

	// Use this for initialization
	void Start () {

        #if DEBUG

        SetupServer();

        #else


        SetupClient();

        #endif
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void SetupServer()
    {
        
        NetworkServer.Listen(4444);
    }

    /*-----  --  ---  -- -- -- --*/

    // Create a client and connect to the server port
    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);     
        myClient.Connect("127.0.0.1", 4444);
    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
        _connected = true;
    }

}
