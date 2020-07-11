using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    Vector3 RespawnPoint;
    public float DeathDepth;

    void Start()
    {
        RespawnPoint = transform.position;
    }

    void Update()
    {
        if(transform.position.y < DeathDepth)
        {
            transform.position = RespawnPoint;
            transform.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
