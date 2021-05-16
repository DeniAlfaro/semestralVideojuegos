using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;


public class GameManager : MonoBehaviourPunCallbacks
{
    public override void OnJoinedRoom()
    {
        GameObject obj = PhotonNetwork.Instantiate("Player", new Vector3(0, 10, 0), Quaternion.identity);
    }
}
