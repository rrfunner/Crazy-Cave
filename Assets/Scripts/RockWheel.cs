using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWheel : MonoBehaviour
{
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 0, speed*Time.deltaTime);
    }
}
