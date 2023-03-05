using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePool : MonoBehaviour
{
    private ObjectPool objectPool;
    private CollectScript collectScript;
    private ResourceFormsScript resourceFormsScript;

    public Action ResourceCollected;


    private bool growed = true;

    void Start()
    {
        PoolScriptReference();
        ResourceFormReference();
        
    }
    private void PoolScriptReference()
    {
        collectScript = FindObjectOfType<CollectScript>();
        collectScript.PoolObject += ReturnPool;
        objectPool = FindObjectOfType<ObjectPool>();
    }
    private void ResourceFormReference()
    {
        resourceFormsScript = GetComponent<ResourceFormsScript>();
        resourceFormsScript.ResourceGrowed += OnGrowed;
    }

        
    private void ResourcesSpawn()
    {
        // Obtem um objeto do pool
        GameObject obj = objectPool.GetObjectFromPool();

        // Configura a posição e rotação do objeto
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
    }
    // Retorna o objeto ao pool
    private void ReturnPool(GameObject obj)
    {
        objectPool.ReturnObjectToPool(obj);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name=="Player"&& growed)
        {
            growed = false;
            ResourcesSpawn();          
            ResourceCollected?.Invoke();
        }
    }
    private void OnGrowed()
    {
        growed = true;
    }
}
