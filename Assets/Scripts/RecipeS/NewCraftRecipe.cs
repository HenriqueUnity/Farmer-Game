using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCraftRecipe : MonoBehaviour
{
    public int resourceCost;
    public GameObject craftItem;
    public string resourceType;
    [SerializeField] private RecipeScript myRecipe;
    void Start()
    {
        resourceType = myRecipe.ResourceType;
        resourceCost = myRecipe.ResourceCost;
        craftItem = myRecipe.CraftItem;

    }

}
