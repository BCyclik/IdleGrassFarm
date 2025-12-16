using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public UnityEvent EventChangeLevel = new();
    public UnityEvent<int> EventRemoveItem = new();
    public UnityEvent<Item> EventAddItem = new();

    [SerializeField] private int level = 1;
    [SerializeField] private List<Item> items = new();
    [Space]
    [SerializeField] private GameObject backPack;

    public int Level => level;
    public int MaxCapacity => DataBase.BaseCapacityInventory + Level * DataBase.AdditionalCapacityPerLevel;

    public bool IsEmpty => items == null || items.Count <= 0;
    public int CountItems => items.Count;
    public bool AddItem(Item item)
    {
        if (MaxCapacity <= items.Count) return false;

        items.Add(item);

        backPack.SetActive(!IsEmpty);

        EventAddItem?.Invoke(item);
        return true;
    }
    public Item RemoveItem(int index)
    {
        var item = items[index];
        items.RemoveAt(index);

        backPack.SetActive(!IsEmpty);
        
        EventRemoveItem?.Invoke(index);
        return item;
    }
    public void LevelUp(int value)
    {
        level += value;
        EventChangeLevel?.Invoke();
    }

    public Item GetLastItem()
    {
        int lastIndex = items.Count - 1;
        return RemoveItem(lastIndex);
    }
}