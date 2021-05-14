using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class ConectionManager : MonoBehaviour
{
    public void Host()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void Join()
    {
        NetworkManager.Singleton.StartClient();
    }
}
