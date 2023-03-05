using TMPro;
using UnityEngine;
using System;
using System.Collections.Generic;

public class CollectScript : MonoBehaviour
{
    public int[] resourceAmount;
    public string[] resourceType = new string [2];
    [SerializeField] private TextMeshProUGUI resourceWoodText;
    [SerializeField] private TextMeshProUGUI resourceSeedText;

    public Dictionary <string, int> resource;
    // Event para o objectpool
    public  Action<GameObject> PoolObject;
    void Start()
    {
        resourceAmount = new int[2];    
        resourceType[0] = "Wood";
        resourceType[1] = "Seeds";
        resourceAmount[0] = 0;
        resourceAmount[1] = 0;  

        resource = new Dictionary <string, int> (2);
        resource.Add(resourceType[0], resourceAmount[0]);
        resource.Add(resourceType[1], resourceAmount[1]);   

        resourceWoodText.text = resource["Wood"].ToString(); 
        resourceSeedText.text = resource["Seeds"].ToString();
    }

   

    private void OnCollisionEnter(Collision other)
    {
        string tag = other.gameObject.tag;
            if (other.gameObject.CompareTag(tag))
                        {
            if(tag == "Wood")
            {
                PoolObject?.Invoke(other.gameObject);
                resource[tag] += 1;
                resourceWoodText.text = resource[tag].ToString();
            }
            if(tag =="Seeds")
            {
                resource[tag] += 1;
                resourceSeedText.text = resource[tag].ToString();
            }
        }
        
        
    }
    public void SpendResource(string resourceType,int ResourceCost)
    {

        int resourceToUse = resource[resourceType];
            resourceToUse -= ResourceCost;
            resource[resourceType] = resourceToUse;
        if(resourceType == "Wood")
        {
           resourceWoodText.text = resource[resourceType].ToString();
        }
        if(resourceType == "Seeds")
        {
            resourceSeedText.text = resource[resourceType].ToString();
        }
    }
}
