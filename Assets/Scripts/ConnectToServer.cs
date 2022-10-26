using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // callbacks function gets called automatically by photon
    // when a certain event happens  
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // Lobby is where players create or join rooms
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        // after joining lobby load Lobby Scene
        SceneManager.LoadScene("Lobby");
    }
}
