using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour
{
    public float Speed = 10;
    int Max = 8;
    bool Up = true;
    Vector3 Rot;

    void Start()
    {
        Rot.y = 90;
        transform.rotation = Quaternion.Euler(Rot);
    }
    void Update()
    {
        if(transform.position.z < Max && Up == true)
        {
            transform.position = transform.position + Vector3.forward * Speed * Time.deltaTime;
        }
        else if (transform.position.z >= Max && Up == true)
        {
            Up = false;
            Rot.y = -90;
            transform.rotation = Quaternion.Euler(Rot);
            transform.position = transform.position + Vector3.back * Speed * Time.deltaTime;
        }
        else if(transform.position.z > 0 && Up == false)
        {
            transform.position = transform.position + Vector3.back * Speed * Time.deltaTime;
        }
        else
        {
            Up = true;
            Rot.y = 90;
            transform.rotation = Quaternion.Euler(Rot);
        }
    }
}
