using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedBox : Box
{

    private GameObject snake;
    private float speed;
    
    private void Start()
    {
        snake = GameObject.FindGameObjectsWithTag("Snake")[0];
        speed = this.transform.parent.GetComponent<SliceMovement>().Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("!");
            snake.GetComponent<SnakeFollow>().TouchingBlockedBox = true;
        }
    }
}
