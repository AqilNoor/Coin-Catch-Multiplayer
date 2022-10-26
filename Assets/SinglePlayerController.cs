using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SinglePlayerController : MonoBehaviour
{
    public static SinglePlayerController instanceSPC;
    public bool canSinglePlayerMove = true;
    [SerializeField]
    float movingSpeed;

    private void Awake()
    {
        if (instanceSPC == null)
        {
            instanceSPC = this;
        }
    }


    void Update()
    {
     
        if (canSinglePlayerMove)
        {
            SinglePlayerMovement();
        }
    }

    public void SinglePlayerMovement()
    {
        float inputX = Input.GetAxis("Horizontal");
        //  a = a + 5
        // a += 5   both have same meaning
        Vector3 currentPosition = transform.position;
        Vector3 changeInPosition = Vector3.right * inputX * movingSpeed * Time.deltaTime;
        Vector3 newPos = currentPosition + changeInPosition;
        newPos.x = Mathf.Clamp(newPos.x, -CoinSpawner.instance.maxX, CoinSpawner.instance.maxX);
        transform.position = newPos;
    }

}
