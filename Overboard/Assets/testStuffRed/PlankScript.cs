using UnityEngine;

public class PlankScript : MonoBehaviour
{
    public bool IsBroken;
    public int ErrorType;
    Color[] Colors = new Color[] {Color.red, Color.blue, Color.green };

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
        ErrorType = 0;
        this.GetComponent<Renderer>().material.color = Color.white;
    }

    void OnTriggerEnter()
    {
        Debug.Log("Trigger");
    }
}
