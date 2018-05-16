using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatedBox : Box
{
    public int NumberOrbs = 1;

    public Text NumberOrbsRequiredText;

    private void Start()
    {
        NumberOrbsRequiredText.text = NumberOrbs.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
