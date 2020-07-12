using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateScript : MonoBehaviour
{
    public int ItemID;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerTileManager>().HitCrate = true;
            other.gameObject.GetComponent<PlayerTileManager>().HitCrateContent = ItemID;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerTileManager>().HitCrate = false;
        }
    }

}
