using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class credit : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject credetmenu;
    public GameObject options;
    public void voidOnclickcredetbutton()
    {
        MainMenu.SetActive(false);
        credetmenu.SetActive(true);

    }

    public void voidOnclickbackbutton()
    {
        MainMenu.SetActive(true);
        credetmenu.SetActive(false);
        options.SetActive(false);


    }
}
