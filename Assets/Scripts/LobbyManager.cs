using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField createRoomInputField;
    public InputField joinInput;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;
    
    public ExistingRoomButton roomItemPrefab;
    List<ExistingRoomButton> currentRoomButtonsList = new List<ExistingRoomButton>();
    public Transform contentObject;
    public float timeBetweenUpdate = 1.5f;
    private float nextUpdateTime;
    private void Start()
    {
        // Lobby is where players create or join rooms
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        // if somthing is written in createRoomInputField
        if (!string.IsNullOrWhiteSpace(createRoomInputField.text))
        {
            PhotonNetwork.CreateRoom(createRoomInputField.text, new RoomOptions() { MaxPlayers = 2 });
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdate;
        }
        
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        // Destroy current room item buttons, if any

        foreach (ExistingRoomButton roomButton in currentRoomButtonsList)
        {
            Destroy(roomButton.gameObject);
        }
        currentRoomButtonsList.Clear();

        //for (int i = 0; i < newRoomButtonsList.Count; i++)
        //{
        //    Destroy(newRoomButtonsList[i].gameObject);
        //    newRoomButtonsList.Remove(newRoomButtonsList[i]);
        //}

        foreach (RoomInfo room in list)
        {
            ExistingRoomButton newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            currentRoomButtonsList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name:  " + PhotonNetwork.CurrentRoom.Name;
        // PhotonNetwork.LoadLevel("Game");
    }

 public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        lobbyPanel.SetActive(true);
        roomPanel.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
}
