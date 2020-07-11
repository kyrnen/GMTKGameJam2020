using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileManager : MonoBehaviour
{
    GameObject CurrentTile = null;
    PlankScript CurrentScript;
    void OnTriggerEnter(Collider other)
    {
        if(CurrentTile != null)
        {
            if (CurrentTile.name != other.gameObject.name)
            {
                Debug.Log("Stopping");
                CurrentScript.StopCollision();
            }
        }

        CurrentTile = other.gameObject;
        CurrentScript = CurrentTile.GetComponent<PlankScript>();
        CurrentScript.StartCollision();
        Debug.Log("Trigger");
    }

    void OnTriggerExit()
    {
        Debug.Log("Exit");
    }
}
