using UnityEngine;

public class KeySetter : MonoBehaviour
{
    [SerializeField]
    int keyIndex;

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
                Keys.SetKey(e.keyCode, keyIndex);
            }
        }
    }
}
