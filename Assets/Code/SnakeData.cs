using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeData : MonoBehaviour
{
    public Text OrbCounter;
    public List<GameObject> AllOrbs;
    public GameObject OrbPrefab;

    private int currNumOrbs, maxNumOrbs;

    private void Start()
    {
        AllOrbs = this.transform.GetComponentsInChildren<HingeJoint2D>().Select(x => x.gameObject).ToList();
    }

    private void Update()
    {
        if (currNumOrbs != this.transform.childCount - 1)
        {
            currNumOrbs = this.transform.childCount - 1;
            maxNumOrbs = Mathf.Max(currNumOrbs, maxNumOrbs);
            OrbCounter.text = currNumOrbs.ToString();
        }
    }

    public void AddOrb()
    {
        var newOrb = Instantiate(OrbPrefab, this.transform);
        newOrb.transform.position = new Vector2(AllOrbs[currNumOrbs - 1].transform.position.x, AllOrbs[currNumOrbs - 1].transform.position.y);
        newOrb.GetComponent<HingeJoint2D>().connectedBody = AllOrbs[currNumOrbs - 1].GetComponent<Rigidbody2D>();
        AllOrbs.Add(newOrb);
    }

    public void RemoveOrb()
    {
        Destroy(AllOrbs[currNumOrbs - 1].gameObject);
        AllOrbs.RemoveAt(currNumOrbs - 1);
    }
}
