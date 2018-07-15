using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    void FixedUpdate()
    {
        mousePosition = new Vector2(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
            cameraRect.xMin + snakeHeadSize.x / 2, cameraRect.xMax - snakeHeadSize.x / 2),
            Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y + snakeHeadSize.y * 1.5f,
            cameraRect.yMin + snakeHeadSize.y / 2, cameraRect.yMax - snakeHeadSize.y / 2));

        Collider2D blockBox = ObjectBetweenTwoPoints(mousePosition, SnakeHead.transform.position, snakeHeadSize.x/3f, "Block");
        if (!(blockBox != null && Physics2D.OverlapCircleAll(SnakeHead.transform.position, snakeHeadSize.x/1.65f).Select(x => x.gameObject.tag).Where(x => x == "Block").Count() > 0))
        {
            SnakeHead.transform.position = Vector2.MoveTowards(SnakeHead.transform.position, mousePosition, MoveSpeed*Time.deltaTime);
        }
    }

    private Collider2D ObjectBetweenTwoPoints(Vector3 currentPos, Vector3 targetPos, float size, string tag)
    {
        var heading = targetPos - currentPos;
        var distance = heading.magnitude;
        return Physics2D.CircleCastAll(currentPos, size, heading, distance)
            .Select(x => x.collider)
            .FirstOrDefault(x => x.gameObject.tag == tag);
    }
}
