using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileManager : MonoBehaviour
{
    GameObject CurrentTile = null;
    PlankScript CurrentScript;
    public int HeldItemID = -2;
    public string FixButton = "e";

    void Update()
    {
        if (Input.GetKeyDown(FixButton))
        {
            HeldItemID = GetComponent<PickUp>().GetObjID();
            if(CurrentScript != null && CurrentScript.GetDamageType() == HeldItemID)
            {
                Debug.Log("Fixing Issue");
                CurrentScript.Repair();
                GetComponent<PickUp>().ResetHolder();
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
