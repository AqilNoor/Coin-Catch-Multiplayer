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
        var inputText = userNameInput.text;
#if UNITY_EDITOR
        if (string.IsNullOrWhiteSpace(inputText))
        {
            inputText = GenerateRandomName();
            PhotonNetwork.NickName = inputText;
        }
#endif

        if (!string.IsNullOrWhiteSpace(inputText))
        {
            PhotonNetwork.NickName = inputText;
            buttonText.text = "Connecting...";
            SceneManager.LoadScene("Loading");
        }
    }
    public void Exit()
    {
        Application.Quit();
    }

    public static string GenerateRandomName()
    {
        var randomName = string.Empty;

        for(int i = 0; i < 6; i++)
        {
            char charatcer =(char) (Random.Range(97, 123));
            randomName += charatcer;
        }

        return randomName;
    }
}
