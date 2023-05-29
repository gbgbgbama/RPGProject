using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScriot : MonoBehaviour
{
    public static int playerIndex = 0;
    public static string playerName = "player";

    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public static void Debug1()
    {
        print("名字现在是:" + playerName);
    }
}