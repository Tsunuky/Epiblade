using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CapacitySlot : MonoBehaviour
{
    public Image icon;
    Capacity capacity;


    public void AddItem(Capacity newItem) {
        capacity = newItem;
        icon.sprite = capacity.icon;
        icon.enabled = true;
    }
    public void ClearSlot() {
        capacity = null;
        icon.sprite = null;
        icon.enabled = false;
    }
    public void UseItem() {
        if (capacity != null) {
            capacity.LvlUp();
        }
    }
}
