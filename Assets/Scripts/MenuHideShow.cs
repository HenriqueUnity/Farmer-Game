using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHideShow : MonoBehaviour
{
    [SerializeField] private GameObject craftMenu;
    void Start()
    {
        craftMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            HideShow();
        }
    }
    public void HideShow()
    {
        if (!craftMenu.activeInHierarchy)
        {
            craftMenu.SetActive(true);
        }
        else
            craftMenu.SetActive(false);
    }
}
