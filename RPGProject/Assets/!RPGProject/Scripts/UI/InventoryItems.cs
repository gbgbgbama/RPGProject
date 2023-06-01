using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject openBook;
    public GameObject closedBook;

    public Image[] emptySlots;

    public static int itemId = 0;
    public static bool iconUpdate = false;

    private int max;

    // Start is called before the first frame update
    private void Start()
    {
        ClosedMenu();
        //默认先让max是道具格子全部数
        max = emptySlots.Length;
    }

    // Update is called once per frame
    private void Update()
    {
        if (iconUpdate)
        {
            for (int i = 0; i < max; i++)
            {
                if (emptySlots[i].sprite == ItemManage.instance.itemIcons[0])
                {
                    max = i;//这里其实就让for语句中断啦,不过我还是加啦break以防万一
                    emptySlots[i].sprite = ItemManage.instance.itemIcons[itemId];
                    //格子里显示的图表类型赋值,让他知道自己是那个道具
                    emptySlots[i].gameObject.GetComponent<HintMessage>().itemId = itemId;
                    break;
                }
            }
            StartCoroutine(Reset());
        }
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.05f);
        iconUpdate = false;
        max = emptySlots.Length;
    }

    public void OpenMenu()
    {
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        Time.timeScale = 0;
    }

    public void ClosedMenu()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        Time.timeScale = 1;
    }
}