using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    public bool canMove = true;
    [SerializeField]
    float moveSpeed;
    public static Player instance;

    public void Awake()
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
        bool isRightButtonPressed = Input.GetKey(KeyCode.RightArrow);
        bool isLeftButtonPressed = Input.GetKey(KeyCode.LeftArrow);
       
        canMove = isRightButtonPressed || isLeftButtonPressed;
        
        if (canMove)
        {
            Move();
        }
    }

    public void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        print(inputX);
        //  a = a + 5
        // a += 5   both have same meaning
        Vector3 currentPosition = transform.position;
        Vector3 changeInPosition = Vector3.right * inputX * moveSpeed * Time.deltaTime;
        Vector3 newPos = currentPosition + changeInPosition;
        newPos.x = Mathf.Clamp(newPos.x, -CoinSpawner.instance.maxX, CoinSpawner.instance.maxX);
        transform.position = newPos;
    }

}
