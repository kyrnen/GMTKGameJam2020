using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollText : MonoBehaviour
{
    public float Speed;
    int StartDepth = -620;
    int EndDepth = 2300;

    void Start()
    {
        transform.localPosition = Vector3.up * StartDepth;
    }
    void Update()
    {
        if(transform.position.y < EndDepth && Speed >= 0)
        {
            transform.localPosition += Vector3.up * Speed * Time.deltaTime;
        }
        if(transform.position.y > StartDepth && Speed < 0)
        {
            transform.localPosition += Vector3.up * Speed * Time.deltaTime;
        }

    }

    public void SetSpeed(float Value)
    {
        Speed = Value;
    }
}
