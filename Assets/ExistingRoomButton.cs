using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExistingRoomButton : MonoBehaviour
{
    public Text roomName;
    LobbyManager lobbyManager;

    private void Start()
    {
        lobbyManager = FindObjectOfType<LobbyManager>();
    }

    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }

    public void OnClickExixtingRoom()
    {
        lobbyManager.JoinRoom(roomName.text);
    }
}
