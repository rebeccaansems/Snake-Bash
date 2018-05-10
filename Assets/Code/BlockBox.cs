using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockBox : MonoBehaviour
{
    public int OrbsRequired = 1;

    public Text OrbsRequiredText;

    private void Start()
    {
        OrbsRequiredText.text = OrbsRequired.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoseOrb(collision.transform.parent.gameObject);
        }
    }

    private void LoseOrb(GameObject parent)
    {
        for (int i = 0; i < OrbsRequired; i++)
        {
            parent.GetComponent<SnakeData>().RemoveOrb();
        }
        Destroy(this.gameObject);
    }
}
