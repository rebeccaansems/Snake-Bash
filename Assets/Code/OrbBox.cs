using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GainNewOrb(collision.transform.parent.gameObject);
        }
    }

    private void GainNewOrb(GameObject parent)
    {
        parent.GetComponent<SnakeData>().AddOrb();
        Destroy(this.gameObject);
    }
}
