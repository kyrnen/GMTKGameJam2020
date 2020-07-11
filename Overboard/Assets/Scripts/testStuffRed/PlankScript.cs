using UnityEngine;

public class PlankScript : MonoBehaviour
{
    public bool IsBroken;
    public int ErrorType;
    bool OnTop = false;
    Color[] Colors = new Color[] {Color.red, Color.blue, Color.green };

    public bool GetStatus()
    {
        return IsBroken;
    }

    public int GetDamageType()
    {
        return ErrorType;
    }

    public void Break(int Type)
    {
        IsBroken = true;
        ErrorType = Type;
        this.GetComponent<Renderer>().material.color = Colors[Type];
    }

    public void Repair()
    {
        Debug.Log("Fixed");
        IsBroken = false;
        ErrorType = -1;
        this.GetComponent<Renderer>().material.color = Color.white;
    }

}
