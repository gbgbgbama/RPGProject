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

    //���ֵ��¼����ǰͼ�����ĸ�.����Ĭ��ֵ0�ǲ���ʾ˵����
    public int iconsType = 0;

    public string[] itemName;
    public string[] itemDescription;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (iconsType > 0)
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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (iconsType > 0)
        {
            overIcon = false;
            hintBox.SetActive(false);
        }
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
        for (int i = 1; i < InventoryItems.pickupItemNum.Length; i++)
        {
            if (iconsType == i)
            {
                message.text = string.Format("{0}\n����:{1}\n���:{2}", itemName[i], InventoryItems.pickupItemNum[i], itemDescription[i]);
            }
        }
    }

    private void Start()
    {
        hintBox.SetActive(false);
        itemName = new string[]
        {
            "",
            "��Ģ��",
            "2",
            "3",
            "��ɫ��",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };
        itemDescription = new string[]
        {
            "",
            "ɭ���ﳣ����Ģ��,��ɫ���Իָ�����",
            "2",
            "3",
            "ɭ���ﳣ���Ļ���,������Ǯ������",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
        };
    }
}