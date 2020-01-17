using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bestUpdater : MonoBehaviour
{
    
    public GameObject tl;
    public Text t;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tl = GameObject.FindGameObjectWithTag("TimeLine");
        t.text = "Best: " + (tl.GetComponent<FinishManager>().best).ToString("{0:0.##}");
    }
}
