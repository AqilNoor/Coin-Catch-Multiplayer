using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject userNamePanel;
    public InputField userNameInput;
    public Text buttonText;
    
    public void ChooseSingleplayer()
    {
        SceneManager.LoadScene("Singleplayer");
    }

    public void ChooseMultiplayer()
    {
        userNamePanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void ConnectToMultiplayer()
    {
        if (!string.IsNullOrWhiteSpace(userNameInput.text))
        {
            PhotonNetwork.NickName = userNameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.LoadLevel("Loading");
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
