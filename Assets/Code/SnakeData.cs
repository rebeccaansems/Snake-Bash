using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeData : MonoBehaviour
{
    public Text OrbCounter;
    public List<GameObject> AllOrbs;
    public GameObject OrbPrefab, MainOrbPrefab, LocalSnakeHead;

    private int currNumOrbs, maxNumOrbs;

    private void Start()
    {
        AllOrbs = this.transform.GetComponentsInChildren<HingeJoint2D>().Select(x => x.gameObject).ToList();
        UpdateText();
    }

    private void UpdateText()
    {
        maxNumOrbs = Mathf.Max(AllOrbs.Count, maxNumOrbs);
        OrbCounter.text = AllOrbs.Count.ToString();
    }

    public void AddOrb()
    {
        GameObject newOrb;
        if (AllOrbs.Count == 0)
        {
            newOrb = Instantiate(MainOrbPrefab, this.transform);
            newOrb.GetComponent<HingeJoint2D>().connectedBody = LocalSnakeHead.GetComponent<Rigidbody2D>();
        }
        else
        {
            newOrb = Instantiate(OrbPrefab, this.transform);
            newOrb.GetComponent<HingeJoint2D>().connectedBody = AllOrbs[AllOrbs.Count - 1].GetComponent<Rigidbody2D>();
        }
        AllOrbs.Add(newOrb);
        newOrb.transform.position = new Vector2(AllOrbs[AllOrbs.Count - 1].transform.position.x, AllOrbs[AllOrbs.Count - 1].transform.position.y);

        UpdateText();
    }

    public void RemoveOrb()
    {
        Destroy(AllOrbs[AllOrbs.Count - 1].gameObject);
        AllOrbs.RemoveAt(AllOrbs.Count - 1);

        UpdateText();
    }
}
