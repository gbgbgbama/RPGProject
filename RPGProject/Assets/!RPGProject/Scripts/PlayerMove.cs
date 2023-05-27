using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent nav;
    private Ray ray;
    private RaycastHit hit;
    private Animator animator;

    private float x, z, velocitySpeed;

    private CinemachineTransposer ct;
    public CinemachineVirtualCamera playerCam;
    private Vector3 pos;
    private Vector3 currPos;

    // Start is called before the first frame update
    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        ct = playerCam.GetCinemachineComponent<CinemachineTransposer>();
        currPos = ct.m_FollowOffset;
    }

    // Update is called once per frame
    private void Update()
    {
        //�����Ǽ���velocitySpeed��ֵ,�����������ֱ�ӵõ�ÿ�����ϵ��ٶ�
        x = nav.velocity.x; z = nav.velocity.z;
        velocitySpeed = x + z;

        //�õ�����λ���������ӽ�
        pos = Input.mousePosition;
        ct.m_FollowOffset = currPos;

        //�õ����������ƶ���ʵ�ֹ���
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                nav.destination = hit.point;
            }
        }
        if (velocitySpeed != 0)
        {
            animator.SetBool("sprinting", true);
        }
        else
        {
            animator.SetBool("sprinting", false);
        }

        if (Input.GetMouseButton(1))
        {
            if (pos.x != 0 || pos.y != 0)
            {
                currPos = pos / 200;
            }
        }
    }
}