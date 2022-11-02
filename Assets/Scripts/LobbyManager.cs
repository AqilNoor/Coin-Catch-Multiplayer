using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField createRoomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName; // Room Name on roomPanel.
    
    // Room in Lobby
    public InSceneRoomButton InSceneRoomItemPrefab;

    // will store available room in lobby
    List<InSceneRoomButton> currentInSceneRoomButtonsList = new List<InSceneRoomButton>();

    // position at which current rooms will be displayed
    public Transform contentObject;
    
    // time to update room list in lobby
    public float timeBetweenUpdate = 1.5f;
    private float nextUpdateTime;
    
    // current players will be stored in this list
    List<PlayerItem> playerItemList = new List<PlayerItem>();
    
    // players that currently playing game
    public PlayerItem playerItemPrefb;
    
    // position at which all players will be displayed in room
    public Transform playerItemParent;
    public GameObject playButton;

    private void Start()
    {
        // Lobby is where players create or join rooms
        PhotonNetwork.JoinLobby();
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2)
        {
            playButton.SetActive(true);
        }
        else
        {
            playButton.SetActive(false);
        }
    }

    public void CreateRoom()
    {
        // if somthing is written in createRoomInputField
        if (!string.IsNullOrWhiteSpace(createRoomInputField.text))
        {                           // enter Room Name           set the max number of player 
            PhotonNetwork.CreateRoom(createRoomInputField.text, new RoomOptions() { MaxPlayers = 3, BroadcastPropsChangeToAll = true });
        }
    }

    // Time.time = 10.5
    // nextUpdateTime = 11

    public override void OnRoomListUpdate(List<RoomInfo> photonRoomList)
    {
        if (Time.time >= nextUpdateTime)
        {
            UpdateRoomList(photonRoomList);
            nextUpdateTime = Time.time + timeBetweenUpdate;
        }
    }

    void UpdateRoomList(List<RoomInfo> photonRoomList)
    {
        // Destroy current room item buttons, if any

        foreach (InSceneRoomButton inSceneRoomButton in currentInSceneRoomButtonsList)
        {
            Destroy(inSceneRoomButton.gameObject);
        }
        currentInSceneRoomButtonsList.Clear();

        // Instantiating new existing room button for each different room available
        foreach (RoomInfo photonRoom in photonRoomList)
        {
            InSceneRoomButton newInSceneRoomButton = Instantiate(InSceneRoomItemPrefab, contentObject);
            newInSceneRoomButton.SetRoomName(photonRoom.Name);
            currentInSceneRoomButtonsList.Add(newInSceneRoomButton);
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
        UpdatePlayerList();
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

    void UpdatePlayerList()
    {
        foreach(PlayerItem item in playerItemList)
        {
            Destroy(item.gameObject);
        }
        playerItemList.Clear();

        if (PhotonNetwork.CurrentRoom == null)
            return;
        
        
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        { 
            PlayerItem newPlayerItem = Instantiate(playerItemPrefb, playerItemParent);
            newPlayerItem.SetPlayerInfo(player.Value);

            if(player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChanges();
            }
            playerItemList.Add(newPlayerItem);
        }
          
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    public void OnClickPlayButton()
    {
        PhotonNetwork.LoadLevel("Multiplayer");
    }
}
