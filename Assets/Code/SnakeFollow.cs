﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFollow : MonoBehaviour
{
    public float MoveSpeed = 0.1f;
    public bool TouchingBlockedBox = false;

    public GameObject SnakeHead;

    private Vector2 mousePosition, snakeHeadSize;
    private Rect cameraRect;

    void Start()
    {
        snakeHeadSize = SnakeHead.GetComponent<Renderer>().bounds.size;
        var bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var topRight = Camera.main.ScreenToWorldPoint(new Vector3(
            Camera.main.pixelWidth, Camera.main.pixelHeight));

        cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y);
    }

    void Update()
    {
        mousePosition = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, cameraRect.xMin + snakeHeadSize.x / 2, cameraRect.xMax - snakeHeadSize.x / 2),
            Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y + snakeHeadSize.y * 1.5f, cameraRect.yMin + snakeHeadSize.y / 2, cameraRect.yMax - snakeHeadSize.y / 2 - 5));
        SnakeHead.transform.position = Vector2.Lerp(SnakeHead.transform.position, mousePosition, MoveSpeed);
    }
}
