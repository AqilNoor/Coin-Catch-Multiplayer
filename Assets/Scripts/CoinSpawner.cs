using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // to set the X position 
    
   public float maxX;

    [SerializeField]
    float spawnInterval;
    // array
    public GameObject[] Coins;

    public static CoinSpawner instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawningCoin();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public void CoinSpawn()
    {
        int rand = Random.Range(0, Coins.Length);
        float randomX = Random.Range(-maxX, maxX);
        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(Coins[rand], randomPos, transform.rotation);
       // print(randomPos);
    }


    IEnumerator SpawnCoins()
    {

        yield return new WaitForSeconds(2f);

        while (true) {
            CoinSpawn();
            yield return new WaitForSeconds(spawnInterval);
        }



        
    }
    public void StartSpawningCoin()
    {
        StartCoroutine("SpawnCoins");

    }


    public void StopSpawningCoin()
    {
        StopCoroutine("SpawnCoins");
    }

}
