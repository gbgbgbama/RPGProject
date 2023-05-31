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

    //这个是用来标记是否显示的
    private bool displaying = true;

    //这个是用来标记,是否鼠标在按键上
    private bool overIcon = false;

    //这个值记录啦当前图标是哪个.其中默认值0是不显示说明的
    public int iconsType = 0;

    public string[] itemName;
    public string[] itemDescription;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (iconsType > 0)
        {
            overIcon = true;
            if (displaying)  //可以显示时候才显示
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
        if (overIcon)//当再图标上按下左键才会让提示消失
        {
            if (Input.GetMouseButtonDown(0))
            {
                displaying = false;
                hintBox.SetActive(false);
            }
        }
        //在任何地方松开左键都会继续显示
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
                message.text = string.Format("{0}\n数量:{1}\n简介:{2}", itemName[i], InventoryItems.pickupItemNum[i], itemDescription[i]);
            }
        }
    }

    private void Start()
    {
        hintBox.SetActive(false);
        itemName = new string[]
        {
            "",
            "红蘑菇",
            "2",
            "3",
            "蓝色花",
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
            "森林里常见的蘑菇,红色可以恢复生命",
            "2",
            "3",
            "森林里常见的花朵,可以卖钱的杂物",
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