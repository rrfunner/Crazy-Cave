using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
   
    private void Start()
    {
        //Player = GameObject.Find("Ball 001");
       
    }

    // [Range(0 , 10)]
    // public float movespeed;


    public void Update()
    {
       
        // Vector3 lerp = target.position.normalized;

        if (  target.position.y < transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z)  ;
        } 

      //  transform.position = Vector3.Lerp(transform.position, lerp, Time.deltaTime * movespeed);
    }
}
