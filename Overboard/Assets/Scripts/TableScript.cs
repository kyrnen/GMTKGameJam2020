using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    public int ItemID = 0;
    int SwapItem = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SwapItem = other.gameObject.GetComponent<PlayerTileManager>().HeldItemID;
            other.gameObject.GetComponent<PlayerTileManager>().ReturnTS = this;
            other.gameObject.GetComponent<PlayerTileManager>().HitCrate = true;
            other.gameObject.GetComponent<PlayerTileManager>().HitCrateContent = ItemID;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerTileManager>().HitCrate = false;
            other.gameObject.GetComponent<PlayerTileManager>().ReturnTS = null;
        }
    }

    public void ReturnPing(int SwapID)
    {
        ItemID = SwapItem;
    }
}
