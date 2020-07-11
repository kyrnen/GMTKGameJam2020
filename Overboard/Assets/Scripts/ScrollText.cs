using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollText : MonoBehaviour
{
    public float Speed;
    int StartDepth = -750;
    int EndDepth = 1700;

    void Start()
    {
        transform.localPosition = Vector3.up * StartDepth;
    }
    void Update()
    {
        if(transform.localPosition.y < EndDepth && Speed >= 0)
        {
            transform.localPosition += Vector3.up * Speed * Time.deltaTime;
        }
        if(transform.localPosition.y > StartDepth && Speed < 0)
        {
            transform.localPosition += Vector3.up * Speed * Time.deltaTime;
        }
    }

    public void SetSpeed(float Value)
    {
        Speed = Value;
    }
}
