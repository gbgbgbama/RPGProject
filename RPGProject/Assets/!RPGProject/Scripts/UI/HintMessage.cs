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

    public void OnPointerEnter(PointerEventData eventData)
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

    public void OnPointerExit(PointerEventData eventData)
    {
        overIcon = false;
        hintBox.SetActive(false);
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
        message.text = "这里是测试消息";
    }

    private void Start()
    {
        hintBox.SetActive(false);
    }
}