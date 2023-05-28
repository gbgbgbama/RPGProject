using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoose : MonoBehaviour
{
    public GameObject[] players;
    public int index = 0;

    private void Start()
    {
        players[index].SetActive(true);
    }

    public void X显示角色向右()
    {
        players[index].SetActive(false);

        index = index < players.Length - 1 ? ++index : 0;
        players[index].SetActive(true);
    }

    public void X显示角色向左()
    {
        players[index].SetActive(false);

        index = index > 0 ? --index : players.Length - 1;
        players[index].SetActive(true);
    }
}