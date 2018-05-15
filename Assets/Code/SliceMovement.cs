using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceMovement : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        transform.Translate(0, -Speed * Time.deltaTime, 0);
    }
}
