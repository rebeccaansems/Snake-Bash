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
        UpdateText();
    }

    private void UpdateText()
    {
        maxNumOrbs = Mathf.Max(AllOrbs.Count, maxNumOrbs);
        OrbCounter.text = AllOrbs.Count.ToString();
    }

    public void AddOrb()
    {
        var newOrb = Instantiate(OrbPrefab, this.transform);
        newOrb.transform.position = new Vector2(AllOrbs[AllOrbs.Count - 1].transform.position.x, AllOrbs[AllOrbs.Count - 1].transform.position.y);
        newOrb.GetComponent<HingeJoint2D>().connectedBody = AllOrbs[AllOrbs.Count - 1].GetComponent<Rigidbody2D>();
        AllOrbs.Add(newOrb);

        UpdateText();
    }

    public void RemoveOrb()
    {
        Destroy(AllOrbs[AllOrbs.Count - 1].gameObject);
        AllOrbs.RemoveAt(AllOrbs.Count - 1);

        UpdateText();
    }
}
