using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceYPosition : MonoBehaviour
{
    private float posY;
    void Start()
    {
        posY = transform.position.y;  
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y != posY)
        {
            transform.position = new Vector3(transform.position.x,posY,transform.position.z);
        }
    }
}
