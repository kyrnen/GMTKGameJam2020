using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankManager : MonoBehaviour
{
    public float TickTime;
    public float IncedentChance;
    public int Cooldown = 0;
    int TimeSinceLast = 0;
    public int[] ProblemOptions = new int[] { };
    float TimeStorage;
    PlankScript[] AllPlanks;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start() => AllPlanks = this.GetComponentsInChildren<PlankScript>();

    // Update is called once per frame
    void Update()
    {
        TimeStorage += Time.deltaTime;
        if(TimeStorage >= TickTime)
        {
            TimeStorage = 0;
            GameTick();
        }
    }

    void GameTick()
    {
        TimeSinceLast++;
        Debug.Log("GameTick");
        if (Random.Range(0, 100) < IncedentChance && TimeSinceLast > Cooldown)
        {
            int LoopIterations = 0;
            PlankScript Target = null;
            while(Target == null && LoopIterations < AllPlanks.Length)
            {
                int Index = Random.Range(0, AllPlanks.Length);
                if (!AllPlanks[Index].IsBroken)
                {
                    Target = AllPlanks[Index];
                    break;
                }
                LoopIterations++;
            }

            if(Target != null)
            {
                int Severity = Random.Range(0, 100);
                int ProblemType = 0;
                int StartSearch = -1;
                for (int i = 0; i < ProblemOptions.Length; i++)
                {
                    if (Severity > StartSearch && Severity < ProblemOptions[i])
                    {
                        ProblemType = i;
                        break;
                    }
                    StartSearch = ProblemOptions[i];
                }
                Debug.Log("Creating Incedent of Type " + ProblemType.ToString());
                Target.Break(ProblemType);
                TimeSinceLast = 0;
            }
            else
            {
                Debug.Log("No Avaliable Target Found");
            }
        }
    }

    void OnTriggerEnter()
    {
        Debug.Log("Trigger");
        transform.position = transform.position + Vector3.up * 0.2f;
    }
    void OnTriggerExit()
    {
        transform.position = transform.position - Vector3.up * 0.2f;
    }
}
