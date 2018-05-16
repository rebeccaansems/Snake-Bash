using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBox : Box
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GainNewOrb(collision.transform.parent.gameObject);
        }
    }

    private void GainNewOrb(GameObject parent)
    {
        parent.GetComponent<SnakeData>().AddOrb();
        StartCoroutine(DestroyObjectWithParticles());
    }
}
