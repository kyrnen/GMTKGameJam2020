using UnityEngine;

public class PlankScript : MonoBehaviour
{
    public bool IsBroken;
    public int ErrorType;
    public GameObject[] TileStates = new GameObject[6];
    ScoreCounter sc;
    public int State = 0;
    public int points = 0;

    public float LoopTime = 5f;
    float TimeBuffer = 0;

    void Start()
    {
        sc = GameObject.Find("Player").GetComponent<ScoreCounter>();
    }

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
        points = 5;
    }

    public void Repair()
    {
        Debug.Log("Fixed");
        sc.AddPoints(5);
        sc.AddFix();
        IsBroken = false;
        TileStates[State].SetActive(false);
        State = 0;
        TileStates[State].SetActive(true);
        ErrorType = -1;
    }
    void Update()
    {
        if(IsBroken == true)
        {
            TimeBuffer += Time.deltaTime;
            if(TimeBuffer >= LoopTime)
            {
                TimeBuffer = 0;
                sc.AddPoints(-1);
            }
        }
    }

}
