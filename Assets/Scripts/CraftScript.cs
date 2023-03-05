using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftScript : MonoBehaviour
{
    private CollectScript m_CollectScript;
    private Vector3 craftArea;
    private GameObject player;
    

    [SerializeField] private List<NewCraftRecipe> recipeScripts = new List<NewCraftRecipe>();
    void Start()
    {
        
        player = GameObject.Find("Player");
        m_CollectScript = player.GetComponent<CollectScript>();
    }


    public void Craft1(int index)
    {
     int resourcecost = recipeScripts[index].resourceCost;
     string resourceType = recipeScripts[index].resourceType;
     int resourceAvalaible = m_CollectScript.resource[resourceType];

        if(resourcecost <= resourceAvalaible)
        {
            GameObject craft = recipeScripts[index].craftItem;
            m_CollectScript.SpendResource(resourceType,resourcecost);
            craftArea = player.transform.position + transform.forward;
            Instantiate(craft, craftArea, transform.rotation);

        }
    }
    //usar os scriptables objects para pegar a informação de quantos resources é preciso para craftar o objeto
    //criar um método para instancialos e usar os botoes do painel para escolher o craft
}
