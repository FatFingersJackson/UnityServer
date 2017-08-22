using UnityEngine;
using UnityEngine.Networking;

public class TestScript : NetworkBehaviour
{

    bool serverIsConnected { get; set; }

    int counter;
    [ClientRpc]
    public void RpcDoMagic(int extra)
    {
        Debug.Log("Magic = " + (123 + extra));
    }

    void Update()
    {
       
            RpcDoMagic(counter);

    }
}