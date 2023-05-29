using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerChoose : MonoBehaviour
{
    public GameObject[] players;
    public int index = 0;

    public InputField inputName;

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

    public void Qȷ��()
    {
        SaveScriot.playerIndex = index;
        SaveScriot.playerName = inputName.text.Length > 0 ? inputName.text : "player";
        SceneManager.LoadScene(1);
    }
}