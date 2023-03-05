using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    private Transform playerPos;
    [SerializeField] private string objectName;
    void Start()
    {
        playerPos = GameObject.Find(objectName).GetComponent<Transform>();    
    }

   
    void LateUpdate()
    {
        transform.position = playerPos.position;
    }
}
