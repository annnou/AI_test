using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBar : MonoBehaviour
{
    [SerializeField]
    GameObject Menu = null;

    bool activeMenu = false;

    void Start()
    {
        
    }

    public void ViewMenu()
    {
        if(!activeMenu)
        {
            activeMenu = true;

            Menu.SetActive(true);
        }
        else
        {
            activeMenu = false;

            Menu.SetActive(false);
        }
    }


}
