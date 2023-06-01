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

    //这个是用来标记是否显示的
    private bool displaying = true;

    //这个是用来标记,是否鼠标在按键上
    private bool overIcon = false;

    //这个值记录啦当前图标是哪个.其中默认值0是不显示说明的
    public int itemId = 0;

    //拿到道具文字信息,通过在InventoryItems在改变图标时候赋值默认是空格子0
    //public IconsTextInfo iconsTextInfo;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemId > 0)
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
        if (itemId > 0)
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
        message.text = string.Format("{0}\n数量:{1}/{2}\n简介:{3}", ItemManage.instance.items[itemId].name, ItemManage.instance.items[itemId].num, ItemManage.instance.items[itemId].maxNum, ItemManage.instance.items[itemId].description);
    }

    private void Start()
    {
        hintBox.SetActive(false);
    }
}