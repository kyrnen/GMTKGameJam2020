using UnityEngine;

public class PlankScript : MonoBehaviour
{
    public bool IsBroken;
    public int ErrorType;
    public GameObject Player;
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

    public void StartCollision()
    {
        OnTop = true;
        this.GetComponent<Renderer>().material.color = Color.yellow;
    }
    public void StopCollision()
    {
        OnTop = false;
        this.GetComponent<Renderer>().material.color = Color.white;
    }
}
