using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject WheelRight;
    public GameObject WheelLeft;
    public bool BackWheels;
    public bool BackFront;
    public float WheelSpeed;
    public float WheelRpmMax;
    public float WheelRotateAngle = 20;

    public void Start()
    {
       // gameObject.GetComponent<Rigidbody>().centerOfMass.Set(new Vector3(0, -0.6 * 2.3, 0));
        
    }

    public void Update()
    {

        if (Input.GetKeyDown("w"))
        {
            WheelRight.GetComponent<WheelCollider>().motorTorque = WheelSpeed;
            WheelLeft.GetComponent<WheelCollider>().motorTorque = WheelSpeed;
        }
        if (Input.GetKeyUp("w"))
        {
            WheelRight.GetComponent<WheelCollider>().motorTorque = 0;
            WheelLeft.GetComponent<WheelCollider>().motorTorque = 0;
        }
        if (Input.GetKeyDown("s"))
        {
            WheelRight.GetComponent<WheelCollider>().motorTorque = -WheelSpeed;
            WheelLeft.GetComponent<WheelCollider>().motorTorque = -WheelSpeed;

        }
        if (Input.GetKeyUp("s"))
        {
            WheelRight.GetComponent<WheelCollider>().motorTorque = 0;
            WheelLeft.GetComponent<WheelCollider>().motorTorque = 0;
        }
        if (Input.GetKeyDown("a"))
        {
            if (BackWheels)
            {
                WheelRight.transform.Rotate(0, -WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, -WheelRotateAngle, 0);
            }
            else
            {
                WheelRight.transform.Rotate(0, WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, WheelRotateAngle, 0);
            }
        }
        if (Input.GetKeyUp("a"))
        {
            if (BackWheels)
            {
                WheelRight.transform.Rotate(0, WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, WheelRotateAngle, 0);
            }
            else
            {
                WheelRight.transform.Rotate(0, -WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, -WheelRotateAngle, 0);
            }
        }

        if (Input.GetKeyDown("d"))
        {
            if (BackWheels)
            {
                WheelRight.transform.Rotate(0, WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, WheelRotateAngle, 0);
            }
            else
            {
                WheelRight.transform.Rotate(0, -WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, -WheelRotateAngle, 0);
            }
        }
        if (Input.GetKeyUp("d"))
        {
            if (BackWheels)
            {
                WheelRight.transform.Rotate(0, -WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, -WheelRotateAngle, 0);
            }
            else
            {
                WheelRight.transform.Rotate(0, WheelRotateAngle, 0);
                WheelLeft.transform.Rotate(0, WheelRotateAngle, 0);
            }
        }
    }
}
