using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text text;
    private float timeleft = 20;
    void Start()
    {
        text.text = timeleft.ToString("F2");
    }

    void Update()
    {
        timeleft -= Time.deltaTime;

        text.text = timeleft.ToString("F2");

        if(timeleft <= 10)
        {
            text.color = Color.red;
        }
        if(timeleft <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
