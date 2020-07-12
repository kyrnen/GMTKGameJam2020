using UnityEngine;
using UnityEngine.UI;

public class PlankScript : MonoBehaviour
{
    public bool IsBroken;
    public int ErrorType;
    public GameObject[] TileStates = new GameObject[6];
    public int State = 0;
    public Text points;
    public int point = 0;

    public float timetofix = 5;

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
        if(Type == 1) { State = 5; }
        if(Type == 2) { State = Random.Range(1, 5); }
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
        if (timetofix <= -5)
        {
            point -= 1;
        }
        if (timetofix <= -10)
        {
            point -= 1;
        }
        if (timetofix <= -15)
        {
            point -= 1;
        }
        if (timetofix <= -20)
        {
            point -= 1;
        }
        if (timetofix <= -30)
        {
            point -= 1;
        }
        if (timetofix <= -35)
        {
            point -= 1;
        }
        if(timetofix >= 0)
            point += 1;
        if (timetofix >= 2)
            point += 1;
        if (timetofix >= 3)
            point += 1;
        if (timetofix >= 4)
            point += 1;
        if (timetofix >= 5)
        {
            point += 1;
        }
        timetofix = 5;

    }
    private void Update()
    {
        points.text = point.ToString("F2");
        timetofix -= Time.deltaTime;

    }

}
