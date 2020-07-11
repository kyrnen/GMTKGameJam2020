using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text text;
    private float timeleft = 100;
    void Start()
    {
        text.text = timeleft.ToString("F2");
    }

    void Update()
    {
        timeleft -= Time.deltaTime;

        text.text = timeleft.ToString("F2");
    }
}
