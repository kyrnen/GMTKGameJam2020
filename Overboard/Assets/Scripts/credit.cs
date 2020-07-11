using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class credit : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject credetmenu;

    public void voidOnclickcredetbutton()
    {
        MainMenu.SetActive(false);
        credetmenu.SetActive(true);


    }
}
