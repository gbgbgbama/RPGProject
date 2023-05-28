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

    public void X��ʾ��ɫ����()
    {
        players[index].SetActive(false);

        index = index < players.Length - 1 ? ++index : 0;
        players[index].SetActive(true);
    }

    public void X��ʾ��ɫ����()
    {
        players[index].SetActive(false);

        index = index > 0 ? --index : players.Length - 1;
        players[index].SetActive(true);
    }
}