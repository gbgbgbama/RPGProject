using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hintBox;
    public Text message;

    private Vector3 screenPoint;

    //�������������Ƿ���ʾ��
    private bool displaying = true;

    //������������,�Ƿ�����ڰ�����
    private bool overIcon = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        overIcon = true;
        if (displaying)  //������ʾʱ�����ʾ
        {
            hintBox.SetActive(true);
            screenPoint.x = Input.mousePosition.x + 220f;
            screenPoint.y = Input.mousePosition.y - 170f;
            screenPoint.z = 1f;
            hintBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            MessageDisplay();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        overIcon = false;
        hintBox.SetActive(false);
    }

    private void Update()
    {
        if (overIcon)//����ͼ���ϰ�������Ż�����ʾ��ʧ
        {
            if (Input.GetMouseButtonDown(0))
            {
                displaying = false;
                hintBox.SetActive(false);
            }
        }
        //���κεط��ɿ�������������ʾ
        if (Input.GetMouseButtonUp(0))
        {
            displaying = true;
        }
    }

    private void MessageDisplay()
    {
        message.text = "�����ǲ�����Ϣ";
    }

    private void Start()
    {
        hintBox.SetActive(false);
    }
}