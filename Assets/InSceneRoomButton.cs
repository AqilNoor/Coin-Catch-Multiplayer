using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InSceneRoomButton : MonoBehaviour
{
    private Text roomNameText;
    LobbyManager lobbyManager;
    Button button;

    private void Start()
    {
        lobbyManager = FindObjectOfType<LobbyManager>();
        roomNameText = transform.GetComponentInChildren<Text>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickExistingRoom);
    }

    public void SetRoomName(string _roomName)
    {
        roomNameText.text = _roomName;
    }


    private void OnClickExistingRoom()
    {
        lobbyManager.JoinRoom(roomNameText.text);
    }
}
