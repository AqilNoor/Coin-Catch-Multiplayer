using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createRoomInputField;
    public InputField joinInput;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemList = new List<RoomItem>();
    public Transform contentObject;

    public void CreateRoom()
    {
        if(createRoomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(createRoomInputField.text, new RoomOptions() {MaxPlayers = 2 });
        }
       
    }

    //public void JoinRoom()
    //{
    //    PhotonNetwork.JoinRoom(joinInput.text);
    //}

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name:  " + PhotonNetwork.CurrentRoom.Name;
        // PhotonNetwork.LoadLevel("Game");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach(RoomItem item in roomItemList)
        {
            Destroy(item.gameObject);
        }
        roomItemList.Clear();
        foreach(RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemList.Add(newRoom);
        }
    }
}
