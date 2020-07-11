using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollText : MonoBehaviour
{
    public float Speed;
    int StartDepth = -800;
    int EndDepth = 2400;

    void Start()
    {
        transform.position = Vector3.up * StartDepth;
    }
    void Update()
    {
        if(transform.position.y < EndDepth)
        {
            transform.position += Vector3.up * Speed * Time.deltaTime;
        }
    }
}
