using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tl;
    public Text t;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tl = GameObject.FindGameObjectWithTag("TimeLine");
        if (tl.GetComponent<FinishManager>().startTime > 0){
            t.text = "Time: " + (Time.time - tl.GetComponent<FinishManager>().startTime).ToString("{0:0.##}");
        }
    }
}
