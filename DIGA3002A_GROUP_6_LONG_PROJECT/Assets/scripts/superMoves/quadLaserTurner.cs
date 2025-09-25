using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadLaserTurner : MonoBehaviour
{
    void Start()
    {
        Debug.Log("RotateDebug attached to " + gameObject.name);
    }


    // Update is called once per frame
    void Update()
    {
        float rotateSpeed = 150f * Time.deltaTime;
        this.transform.Rotate(0f, rotateSpeed, 0f);
        Debug.Log("is it working?");
    }
}
