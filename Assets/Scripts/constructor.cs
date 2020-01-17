using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class constructor : MonoBehaviour
{
    public List<GameObject> objects;
    public int n = 0;
    //public List<GamObject> prefabs = new List<GameObject>();
    public GameObject []prefabs;
    public float angle = 0f;
    public int count = 0;
    public GameObject but;
    public GameObject butSh;
    public bool flag;   
    public GameObject MyStart(Pose p)
    {
        objects.Add(GameObject.Instantiate(prefabs[0], p.position, Quaternion.Euler(0f, 0f, 0f)));
        return objects[0];
    }

    public void Start()
    {
            but.SetActive(false);
            flag = false;
            butSh.GetComponentInChildren<Text>().text = "развернуть";
        //objects.Add(GameObject.Instantiate(begin, gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f)));
    }

    public void placeNext(int idx){
        var x = objects[objects.Count - 1].transform.GetChild(0).transform;
        objects.Add(GameObject.Instantiate(prefabs[idx], x.position, Quaternion.Euler(0f, angle, 0f)));
        if (idx == 3){
            angle -= 90;
        }
        if (idx == 2){
            angle += 90;
        }
    }

    public void restart(){
         Application.LoadLevel("MainScene");
    }
       public void del()
    {
        if (objects.Count > 0)
        {
           if( objects[objects.Count - 1].name == "RR 1(Clone)")
            {
                angle -= 90f; 
            }
           else if(objects[objects.Count - 1].name == "LLC(Clone)")
            {
                angle += 90f;
            }
            Destroy(objects[objects.Count - 1]);
            objects.RemoveAt(objects.Count - 1);
            n--;
        }
    }
        public void show(){
        if(flag){
            but.SetActive(false);
            flag = false;
            butSh.GetComponentInChildren<Text>().text = "развернуть";
        }else
        {
              but.SetActive(true);
            flag = true;
            butSh.GetComponentInChildren<Text>().text = "свернуть";
        }

    }
}
