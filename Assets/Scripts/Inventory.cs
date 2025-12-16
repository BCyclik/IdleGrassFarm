using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private int InitCapacity = 5;
    [SerializeField] private List<Item> items = new();

    public int Level => level;
    public int MaxCapacity => InitCapacity + Level * DataBase.AdditionalCapacityPerLevel;

    public bool IsEmpty => items == null || items.Count <= 0;

    public bool AddItem(Item item)
    {
        if (MaxCapacity <= items.Count) return false;

        items.Add(item);
        return true;
    }
    public Item RemoveItem(int index)
    {
        var item = items[index];
        items.RemoveAt(index);

        return item;
    }
    public void LevelUp(int value)
    {
        level += value;
    }

    public Item GetLastItem()
    {
        int lastIndex = items.Count - 1;
        return RemoveItem(lastIndex);
    }
}