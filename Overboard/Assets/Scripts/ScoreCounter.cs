using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour
{
    int Points = 0;
    int FixNumber;
    public Image[] StarDrops = new Image[3];
    public Sprite[] StarState = new Sprite[2];
    public Text PointDisplay;
    public Text FixDisplay;
    public Text TillNext;
    public Text RunPoints;
    public Text RunTime;
    public Text Interact;
    public Text Dash;
    public int[] PointsToStar = new int[3];
    public string[] ButtonScenes = new string[3];
    public GameObject End;
    public GameObject Run;
    public float Timer = 120;
    bool Running = true;

    void Start()
    {
        Interact.text = "Interact: " + Keys.GetKey(1);
        Dash.text = "Dash: " + Keys.GetKey(0);
    }

    void Update()
    {
        if (Running)
        {
            Timer -= Time.deltaTime;
            RunTime.text = "Time left: " + (Mathf.FloorToInt(Timer / 60)).ToString() + ":" + (Mathf.FloorToInt(Timer % 60)).ToString();
            if (Timer <= 0)
            {
                Running = false;
                EndOfTime();
            }
        }
    }

    public void AddPoints(int Value)
    {
        if (Running)
        {
            Points += Value;
            Debug.Log("Adding Points: "+ Points);
            RunPoints.text = "Point: "+Points.ToString();
        }
    }

    public void AddFix()
    {
        if (Running)
        {
            FixNumber++;
        }
    }

    public void EndOfTime()
    {
        End.SetActive(true);
        Run.SetActive(false);
        FixDisplay.text = FixNumber.ToString();
        PointDisplay.text = "Reached Points: " + Points.ToString();
        int toNext = 0;
        for (int i = 0; i < 3; i++)
        {
            if (Points >= PointsToStar[i])
            {
                StarDrops[i].sprite = StarState[1];
            }
            else
            {
                toNext = PointsToStar[i] - Points;
                break;
            }
        }
        TillNext.text = "Points to next Star: " + toNext.ToString();
    }

    //Menu Stuff!

    public void SceneStuff(int ID)
    {
        SceneManager.LoadScene(ButtonScenes[ID]);
    }
}