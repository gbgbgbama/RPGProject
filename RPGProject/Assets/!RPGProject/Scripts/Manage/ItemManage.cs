using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManage : MonoBehaviour
{
    public static ItemManage instance;
    public List<ItemBasic> items;
    public Sprite[] itemIcons;

    public int gold;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
}

[System.Serializable]
public class ItemBasic
{
    public int id;
    public string name;
    public string description;

    public int num = 0;
    public int maxNum = 99;
    public int price = 10;

    public bool isOverlay = true;
    public bool isUsed = true;
    //public int ceshi = 0;

    public ItemBasic(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public void AddNum(int a = 1)
    {
        num += a;
        if (num > maxNum)
        {
            num = maxNum;
        }
    }
}