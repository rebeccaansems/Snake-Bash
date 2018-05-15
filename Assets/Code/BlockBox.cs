using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockBox : Box
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoseOrb(collision.transform.parent.gameObject);
        }
    }

    private void LoseOrb(GameObject parent)
    {
        for (int i = 0; i < NumberOrbs; i++)
        {
            parent.GetComponent<SnakeData>().RemoveOrb();
        }
        StartCoroutine(DestroyObjectWithParticles());
    }
}
