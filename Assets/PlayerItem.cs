using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class PlayerItem : MonoBehaviourPunCallbacks
{
    public Text playerNmae;
    Image backgroundImage;
    public Color highlightColor;
    public GameObject leftArrowButton;
    public GameObject rightArrowButton;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    public Image playerAvatar;
    public Sprite[] avatars;

    // Player is pre-made photon type that describes diff players in our game
    Player player;

    private void Awake ()
    {
        backgroundImage = GetComponent<Image>();
    }

    private void Start()
    {
        player.CustomProperties["playerAvatar"] = 0;
    }

    public void SetPlayerInfo(Player _player)
    {
        playerNmae.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player); 
    }

    public void ApplyLocalChanges()
    {
        backgroundImage.color = highlightColor;
        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
    }

    public void OnClickLeftArrow()
    {
        if ((int)playerProperties["playerAvatar"] == 0)
        {
            playerProperties["playerAvatar"] = avatars.Length - 1;
        }
        else
        {
            playerProperties["playerAvatar"] = (int)playerProperties["playerAvatar"] - 1;
        }

        //notify other players in room custom properties a player has been changed
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void OnClickRightButton()
    {   // imageIndex = 0
        // avatars.Length - 1 = 2

        int imageIndex = (int) playerProperties["playerAvatar"];
        
        if ( imageIndex == avatars.Length - 1)
        {
            playerProperties["playerAvatar"] = 0;
        }
        else
        {
            playerProperties["playerAvatar"] = imageIndex + 1;
        }

        //notify other players in room custom properties a player has been changed
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        // the player who's properties is changed, will be stored in  targetPlayer
       if(player == targetPlayer)
       {
            UpdatePlayerItem(targetPlayer);
       }
    }

    void UpdatePlayerItem(Player player)
    {
        // if player with custom properties has playerAvatarImage
        if (player.CustomProperties.ContainsKey("playerAvatar"))
        {
            // setting the sprite equal to (ARRAY) avatar with index player.CustomProperties["playerAvatarImage"]
            // Since hashtable store data in form of c# objects so when we try
            // to retrieve any data, we will get c# boxed object 
            object playerAvatarImageObject = player.CustomProperties["playerAvatar"];

            // Now we will convert this boxed object to int
            int playerAvatarImageObjectIndex = (int) playerAvatarImageObject;

            playerAvatar.sprite = avatars[playerAvatarImageObjectIndex];

            playerProperties["playerAvatar"] = playerAvatarImageObjectIndex;
        }
        else
        {
            playerProperties["playerAvatar"] = 0;
        }
    }
}
