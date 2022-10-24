using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag =="Player")
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
