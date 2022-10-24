using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField]
    float moveSpeed;
    
    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    public void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        //  a = a + 5
        // a += 5   both have same meaning
        Vector3 currentPosition = transform.position;
        Vector3 changeInPosition = Vector3.right * inputX * moveSpeed * Time.deltaTime;
        Vector3 newPos = currentPosition + changeInPosition;
        newPos.x = Mathf.Clamp(newPos.x, -CoinSpawner.instance.maxX, CoinSpawner.instance.maxX);
        transform.position = newPos;
    }

}
