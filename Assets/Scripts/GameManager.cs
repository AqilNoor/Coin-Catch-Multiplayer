using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // to manage the Score
    int score = 0;
    bool gameOver = false;
    // using UnityEngine.UI
    public Text scoreText;
    // to manage live 
    public int lives = 3;
    // For LivesPanel 
    public GameObject LiveHlder;
    // For game over panel
    public GameObject gameOverPanel;

   

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
       
    }
   
    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            SoundManager.instance.PlayCoinCollectSound();
            //scoreText is a string = score is int 
            scoreText.text = score.ToString();
        }
    }

    public void DecreaseLife()
    {
        if (lives > 0)
        { lives--;
            // print(lives);
            LiveHlder.transform.GetChild(lives).gameObject.SetActive(false);
        }
        if(lives == 0)
        { 
            gameOver = true;
            GameOver();
        }
    }

    public void GameOver()
    {
        CoinSpawner.instance.StopSpawningCoin();   
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
