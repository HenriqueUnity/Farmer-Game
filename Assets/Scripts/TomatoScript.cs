using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TomatoScript : MonoBehaviour
{
    public int tomatoAmount;
    [SerializeField] private TextMeshProUGUI tomatoText;
    void Start()
    {
        tomatoText.text = tomatoAmount.ToString();
    }
        
    public void TomatoTaken()
    {
        tomatoAmount++;
        tomatoText.text = tomatoAmount.ToString();
    }
}
