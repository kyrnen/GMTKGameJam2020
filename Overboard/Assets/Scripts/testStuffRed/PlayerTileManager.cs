using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileManager : MonoBehaviour
{
    GameObject CurrentTile = null;
    PlankScript CurrentScript;
    public int HeldItemID = -2;
    public int PlayerNumber = 1;

    void Update()
    {
        if (Input.GetKeyDown(Keys.GetKey(2+(PlayerNumber-1)*3)))
        {
            if(CurrentScript != null && CurrentScript.GetDamageType() == HeldItemID)
            {
                Debug.Log("Fixing Issue");
                CurrentScript.Repair();
                HeldItemID = -2;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        CurrentTile = other.gameObject;
        CurrentScript = CurrentTile.GetComponent<PlankScript>();
        Debug.Log("Trigger");
    }

}
