using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerinstintiate : MonoBehaviour
{
    public GameObject gameojecttospawn;

    public Vector3 vector;

    public Transform GameObject;

    public int Type;

    bool check;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && check == true)
        {
            Debug.Log("spawn");
            Instantiate(gameojecttospawn);
            check = false;
        }
    }

    public int GetItemType()
    {
        return Type;
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("g");
        if (collider.tag == "G")
        {
            check = true;
        }
    }
}
