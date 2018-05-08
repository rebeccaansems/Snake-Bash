using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFollow : MonoBehaviour
{

    public float MoveSpeed = 0.1f;

    private Vector2 mousePosition, selfSize;
    private Rect cameraRect;

    void Start()
    {
        selfSize = GetComponent<Renderer>().bounds.size;
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
        mousePosition = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, cameraRect.xMin + selfSize.x / 2, cameraRect.xMax - selfSize.y / 2), transform.position.y);
        transform.position = Vector2.Lerp(transform.position, mousePosition, MoveSpeed);
    }
}
