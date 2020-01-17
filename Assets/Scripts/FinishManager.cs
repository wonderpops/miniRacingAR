using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinishManager : MonoBehaviour
{
    public GameObject st;
    public Text text;
    public float startTime;
    public float finishTime;
    public bool seccrossl;
    public float best;
    public bool zal = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log(st.GetComponent<StartManager>().isFirstCross);
        Debug.Log(seccrossl);
        if (st.GetComponent<StartManager>().isFirstCross){
            st.GetComponent<StartManager>().isFirstCross = false;
            //if (seccrossl) {
                
                finishTime = Time.time - startTime;
                if (best != 0){
                        Debug.Log(finishTime);
                        Debug.Log(best);
                    if (finishTime < best){
                        Debug.Log(finishTime);
                        Debug.Log(best);
                        best = finishTime;
                    }
                } else {
                    if (zal){
                        best = finishTime;
                    }
                    zal = true;
                }
                startTime = st.GetComponent<StartManager>().strt;
                seccrossl = false;
            //} else {
               // seccrossl = true;
                //startTime = st.GetComponent<StartManager>().strt;
            //}
        }
    }
}
