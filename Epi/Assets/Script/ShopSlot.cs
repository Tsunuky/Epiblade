using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class ShopSlot : MonoBehaviour
{
    public Image icon;
    public Text price;
    public Text name;
    Item item;

    public void AddItem(Item newItem) {
        item = newItem;
        icon.sprite = item.icon;
        price.text = item.price.ToString();
        name.text = item.name;
        icon.enabled = true;
    }

    public void ClearSlot() {
        item = null;
        icon.sprite = null;
        name.text = "";
        price.text = "";
        icon.enabled = false;
    }

    public void BuyItem() {
        if (item != null) {
            item.Buy();
        }
    }
}
