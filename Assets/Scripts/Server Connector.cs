using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class ServerConnector : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom("room", roomOptions, TypedLobby.Default);       
    }
}
