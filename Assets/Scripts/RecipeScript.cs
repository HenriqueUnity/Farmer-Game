using UnityEngine;
[CreateAssetMenu(fileName ="Recipe",menuName ="NewRecipe")]
public class RecipeScript : ScriptableObject
{
    public int ResourceCost;
    public GameObject CraftItem;
    public string ResourceType;
}
