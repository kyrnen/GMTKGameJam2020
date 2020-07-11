using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class credit : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject creditmenu;
    public GameObject options;
    public void voidOnclickcredetbutton()
    {
        MainMenu.SetActive(false);
        creditmenu.SetActive(true);

    }

    public void voidOnclickbackbutton()
    {
        MainMenu.SetActive(true);
        creditmenu.SetActive(false);
        options.SetActive(false);


    }
}
