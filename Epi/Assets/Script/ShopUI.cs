using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ShopUI : MonoBehaviour
{
    public Transform itemsParent;
    ShopSlot[] slots;
    List<Item> items = new List<Item>();
    public Item first;
    public Item second;
    public Item third;

    void Start()
    {
        items.Add(first);
        items.Add(second);
        items.Add(third);
        slots = itemsParent.GetComponentsInChildren<ShopSlot>();
        for (int i = 0; i < slots.Length ; i++) {
            if (i < items.Count) {
                slots[i].AddItem(items[i]);
            } else
                slots[i].ClearSlot();
        }
    }

    void Update()
    {
    }
}
