using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // increment score
            GameManager.instance.IncrementScore();
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Boundary")
        {
            // decrement score
            GameManager.instance.DecreaseLife();
            Destroy(gameObject);
        }
    }
}
