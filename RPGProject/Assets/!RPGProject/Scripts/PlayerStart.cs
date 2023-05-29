using Cinemachine;

using UnityEngine;
using UnityEngine.AI;

public class PlayerStart : MonoBehaviour
{
    public GameObject[] players;
    public int index = 0;
    private GameObject player;

    public CinemachineVirtualCamera playerCam;
    public GameObject moveVfx;

    // Start is called before the first frame update
    private void Start()
    {
        index = SaveScriot.playerIndex;
        player = Instantiate(players[index], transform.position, transform.rotation);
        player.GetComponent<NavMeshAgent>().enabled = true;
        player.GetComponent<PlayerMove>().enabled = true;
        player.GetComponent<PlayerMove>().playerCam = playerCam;
        player.GetComponent<PlayerMove>().moveVfx = moveVfx;
        playerCam.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        playerCam.GetComponent<CinemachineVirtualCamera>().LookAt = player.transform;
        Destroy(gameObject);
    }
}