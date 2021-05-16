using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Spawning;
using System;
using Random=UnityEngine.Random;// Si sale error con random cambiarlo por: Random=System.Random
using MLAPI.Transports.UNET;

public class ConectionManager : MonoBehaviour
{
    public GameObject ConnectionButtonPanel; 

    public string IpAddress = "127.0.0.1";

    UNetTransport transport;

    public void Host()
    {
        ConnectionButtonPanel.SetActive(false);
        NetworkManager.Singleton.ConnectionApprovalCallback += ApprovalCheck; 
        NetworkManager.Singleton.StartHost(GetRandomSpawn(), Quaternion.identity);
        
    }

    public void ApprovalCheck( byte[] connectionData , ulong clientID, NetworkManager.ConnectionApprovedDelegate callback)
    {
        //Debug.Log("Approving a connection");
        bool approve = System.Text.Encoding.ASCII.GetString(connectionData) == "Password1234";
        callback(true, null, approve, GetRandomSpawn(), Quaternion.identity);
    }

    public void Join()
    {
        transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
        transport.ConnectAddress = IpAddress;
        ConnectionButtonPanel.SetActive(false);
        NetworkManager.Singleton.NetworkConfig.ConnectionData = System.Text.Encoding.ASCII.GetBytes("Password1234");
        NetworkManager.Singleton.StartClient();
    }

    Vector3 GetRandomSpawn()
    {
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-10f, 10f);
        float z = Random.Range(-10f, 10f);

        return new Vector3(x,y,z);
    }

    public void IpAddressChanged(string newAddress) {
        this.IpAddress = newAddress;
    }
    
}
