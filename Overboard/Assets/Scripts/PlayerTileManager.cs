using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileManager : MonoBehaviour
{
    PlankScript CurrentScript;
    public int HeldItemID = -2;
    public int PlayerNumber = 1;
   
    private RaycastHit prev ;
    PlayerMovement p;
    private void Start()
    {
         p = GetComponent<PlayerMovement>();
    }

    
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(p.getPlayerPosition(), Vector3.down, out hit))
        {
            if (!prev.Equals(hit))
            {
                prev = hit;
                CurrentScript = hit.collider.gameObject.GetComponent<PlankScript>();
                Debug.Log("Trigger");
            }
        }
    }


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

}
