using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    [SerializeField] private string plantName = "default plant";
    private bool canHarvest = false;
    private bool newShape = false;
    private bool seedReady = false;
    private GameObject player;

    [Header("Time Variables")]
    [SerializeField] private readonly float timeToGrow = 5f;
    [SerializeField] private float timer;

    [Header("Shapes")]
    [SerializeField] private GameObject firstShape;
    [SerializeField] private GameObject secondShape;
    [SerializeField] private GameObject fruitShape;
    void Start()
    {
        player = GameObject.Find("Player");
        firstShape.SetActive(false);
    }

    
    void Update()
    {
        if(seedReady)
        {         
        timer += Time.deltaTime;
        }

        if(timer >= timeToGrow && !newShape)
        {
         newShape = true;
         firstShape.SetActive(false);
         secondShape.SetActive(true);
         timer = 0;
        }
        else if(timer >= timeToGrow && !canHarvest)
        {
            canHarvest = true;
            fruitShape.SetActive(true);
            seedReady = false;
            timer = 0;
           
        }
    }

    private void OnCollisionStay(Collision other)
    {
       if(other.gameObject.name == "Player")
        {
            if(!canHarvest)
            {
                
            if (Input.GetKeyDown(KeyCode.E) && !seedReady && ResourceCheck())
            {
               player.GetComponent<CollectScript>().SpendResource("Seeds", 1);
               seedReady = true;
               firstShape.SetActive(true);
            }
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
                canHarvest = false;
                player.GetComponent<TomatoScript>().TomatoTaken();
                firstShape.SetActive(false);
                secondShape.SetActive(false);
                fruitShape.SetActive(false);
            }

        }
    }
    private bool ResourceCheck()
    {
        if(player.GetComponent<CollectScript>().resource["Seeds"] > 0)
            return true;
        else
            return false;
    }


}
