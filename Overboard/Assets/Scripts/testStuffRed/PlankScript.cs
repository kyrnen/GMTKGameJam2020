using UnityEngine;

public class PlankScript : MonoBehaviour
{
    public bool IsBroken;
    public int ErrorType;
    GameObject Player;
    bool OnTop = false;
    Color[] Colors = new Color[] {Color.red, Color.blue, Color.green };

    void Update()
    {
        if(OnTop && IsBroken && Player.GetComponent<PickUp>().GetObjID() == ErrorType) //Check if Standing on Broken Tile with correct Equipment for Fix
        {
            Repair(); //Fix Stuff!
        }
    }

    public bool GetStaus()
    {
        return IsBroken;
    }

    public void Break(int Type)
    {
        IsBroken = true;
        ErrorType = Type;
        this.GetComponent<Renderer>().material.color = Colors[Type];
    }

    public void Repair()
    {
        IsBroken = false;
        ErrorType = -1;
        this.GetComponent<Renderer>().material.color = Color.white;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        Player = other.gameObject;
        OnTop = true;
    }
    
    void OnTriggerExit()
    {
        OnTop = false;
    }
}
