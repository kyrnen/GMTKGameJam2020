using UnityEngine;

public static class Keys
{
    public static KeyCode[] keys = new KeyCode[3];

    public static void SetKey(KeyCode keyCode, int index)
    {
        keys[index] = keyCode;
    }
}
