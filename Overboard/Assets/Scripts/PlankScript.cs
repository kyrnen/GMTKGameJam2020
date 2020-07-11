using UnityEngine;

public class PlankScript : MonoBehaviour
{
    public bool IsBroken;
    public int ErrorType;
    bool OnTop = false;
    public GameObject[] TileStates = new GameObject[5];
    public int State = 0;


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
        TileStates[State].SetActive(false);
        State = Random.Range(1, 5);
        TileStates[State].SetActive(true);
    }

    public void Repair()
    {
        Debug.Log("Fixed");
        IsBroken = false;
        TileStates[State].SetActive(false);
        State = 0;
        TileStates[State].SetActive(true);
        ErrorType = -1;

    }

}
