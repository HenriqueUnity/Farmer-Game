using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceFormsScript : MonoBehaviour
{
    private ResourcePool resource;
   [SerializeField] private GameObject resourceCollectedForm;
   [SerializeField] private GameObject resourceDefaultForm;
    private float timer;
    private bool collected;

    public Action ResourceGrowed;

    
    void Start()
    {
        resourceCollectedForm.SetActive(false);
        resource = GetComponent<ResourcePool>();
        resource.ResourceCollected+= OnResourceCollected;
    }
    private void Update()
    {
        if(collected)
        {
            timer += Time.deltaTime;
            if(timer >5)
            {
                ResourceGrow();
            }
        }
        
    }
    //recurso foi coletado
    private void OnResourceCollected()
    {
        resourceDefaultForm.SetActive(false);
        resourceCollectedForm.SetActive(true);
        collected = true;
    }
    //recurso pronto para ser coletado novamente 
    private void ResourceGrow()
    {
        resourceCollectedForm.SetActive(false);
        resourceDefaultForm.SetActive(true) ;
        collected = false;
        timer = 0;
        ResourceGrowed?.Invoke();

    }
}
