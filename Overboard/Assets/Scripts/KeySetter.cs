using UnityEngine;
using UnityEngine.UI;

public class KeySetter : MonoBehaviour
{
    GameObject currentBind;

    private void Update()
    {
        currentBind = GameObject.FindGameObjectWithTag("Keybind");
        currentBind.GetComponentInChildren<Text>().text = Keys.GetKey(1).ToString();
    }
    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            if (e.keyCode != KeyCode.None)
            {
                Keys.SetKey(e.keyCode, 1);
            }
        }
    }
}
