using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileManager : MonoBehaviour
{
    public GameObject[] ItemsHeld = new GameObject[3];
    PlankScript CurrentScript;
    public int HeldItemID = 0;
    public int PlayerNumber = 1;

    public bool HitCrate = false;
    public TableScript ReturnTS;
    public int HitCrateContent;

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

        if (Input.GetKeyDown(Keys.GetKey(1 + (PlayerNumber - 1) * 2)))
        {
            if (HitCrate)
            {
                if(ReturnTS != null)
                {
                    ReturnTS.ReturnPing(HeldItemID);
                }
                ChangeHeldItem(HitCrateContent);
            }
        }
    }


    void Update()
    {

        if (Input.GetKeyDown(Keys.GetKey(1+(PlayerNumber-1)*2)))
        {
            if(CurrentScript != null && CurrentScript.GetDamageType() == HeldItemID)
            {
                Debug.Log("Fixing Issue");
                CurrentScript.Repair();
                ChangeHeldItem(0);
            }
        }
    }

    public void ChangeHeldItem(int ID)
    {
        Debug.Log(ID);
        ItemsHeld[HeldItemID].gameObject.SetActive(false);
        ItemsHeld[ID].gameObject.SetActive(true);
        HeldItemID = ID;
    }
}
