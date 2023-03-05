using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedCollector : MonoBehaviour
{
    private bool collected = false;
    private float timer = 5;

    private Material material;
    private BoxCollider myCollider;
    private void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        material = GetComponent<MeshRenderer>().material;
        material.color = Color.red;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Player" && !collected)
        {
            collected = true;
            material.color = Color.white;
            myCollider.enabled = false;
            StartCoroutine(Timer());
        }
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        collected = false;
        myCollider.enabled = true;
        material.color = Color.red;
    }
}
