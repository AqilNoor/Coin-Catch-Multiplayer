using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      

    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            SoundManager.instance.audioSource.PlayOneShot(SoundManager.instance.coinCollect);
            //scoreText is a string = score is int 
            scoreText.text = score.ToString();
            // print(score);


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
        { gameOver = true;
            GameObject bgAudioObject = GameObject.Find("BGAudio");
            if(bgAudioObject != null)
            {
                bgAudioObject.SetActive(false);
            }
            SoundManager.instance.audioSource.PlayOneShot(SoundManager.instance.gameOverAudio);
            GameOver();
        }
    }

    public void GameOver()
    {
       
        CoinSpawner.instance.StopSpawningCoin();

        //  Raja code
       // GameObject.Find("Player").GetComponent<Player>().canMove = false;

        // Aqil code
        Player.instance.canMove = false;
        gameOverPanel.SetActive(true);
        print("GameOver");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
