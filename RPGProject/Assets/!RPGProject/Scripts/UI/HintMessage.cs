using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.ShaderData;

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
    public int itemId = 0;

    //�õ�����������Ϣ,ͨ����InventoryItems�ڸı�ͼ��ʱ��ֵĬ���ǿո���0
    //public IconsTextInfo iconsTextInfo;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemId > 0)
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
        if (itemId > 0)
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
        message.text = string.Format("{0}\n����:{1}/{2}\n���:{3}", ItemManage.instance.items[itemId].name, ItemManage.instance.items[itemId].num, ItemManage.instance.items[itemId].maxNum, ItemManage.instance.items[itemId].description);
    }

    private void Start()
    {
        hintBox.SetActive(false);
    }
}