using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
  //  private GameObject Player;
    public GameObject[] playerPrefabs;
   // public Transform[] spawnPoints;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        // int randomNumber = Random.Range(0, spawnPoints.Length);
        // Transform spawnPoint = spawnPoints[randomNumber];
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]);
        GameObject playerToSpawn = playerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"]];
        PhotonNetwork.Instantiate(playerToSpawn.name, randomPosition, Quaternion.identity);
      
        //Player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        //Player.name = "Player";
    }
}
