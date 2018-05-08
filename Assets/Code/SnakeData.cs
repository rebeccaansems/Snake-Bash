using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnakeData : MonoBehaviour
{
    public Text OrbCounter; 

    private int currNumOrbs, maxNumOrbs;
    
    // Update is called once per frame
    void Update()
    {
        if (currNumOrbs != this.transform.childCount - 1)
        {
            currNumOrbs = this.transform.childCount - 1;
            maxNumOrbs = Mathf.Max(currNumOrbs, maxNumOrbs);
            OrbCounter.text = currNumOrbs.ToString();
        }
    }
}
