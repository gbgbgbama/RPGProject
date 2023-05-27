using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursors : MonoBehaviour
{
    public GameObject cursorObject;
    public Sprite cursorBasic;
    public Sprite cursorHand;
    public Image cursorImage;

    // Start is called before the first frame update
    private void Start()
    {
        //隐藏默认的鼠标光标
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        cursorObject.transform.position = Input.mousePosition;
        if (Input.GetMouseButton(1))
        {
            cursorImage.sprite = cursorHand;
        }
        if (Input.GetMouseButtonUp(1))
        {
            cursorImage.sprite = cursorBasic;
        }
    }
}