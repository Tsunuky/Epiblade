using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Transform capacityParent;
    Inventory inventory;
    InventorySlot[] slots;
    CapacitySlot[] cSlot;
    List<Capacity> capacity = new List<Capacity>();
    public Capacity SA;
    public Capacity H;
    public Capacity DU;
    public GameObject inventoryUI;
    public GameObject inventoryMenu;
    public GameObject statsMenu;
    public GameObject capacityMenu;

    void Start()
    {
        capacity.Add(SA);
        capacity.Add(H);
        capacity.Add(DU);
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        cSlot = capacityParent.GetComponentsInChildren<CapacitySlot>();
        Debug.Log(cSlot.Length);
        Debug.Log(slots.Length);
        for (int i = 0; i < cSlot.Length ; i++) {
            if (i < capacity.Count) {
                cSlot[i].AddItem(capacity[i]);
            } else
                cSlot[i].ClearSlot();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void ClicInventory() {
        inventoryMenu.SetActive(true);
        statsMenu.SetActive(false);
        capacityMenu.SetActive(false);
    }

    public void ClicStats() {
        inventoryMenu.SetActive(false);
        statsMenu.SetActive(true);
        capacityMenu.SetActive(false);
    }

    public void ClicCapacity() {
        inventoryMenu.SetActive(false);
        statsMenu.SetActive(false);
        capacityMenu.SetActive(true);
    }
    void UpdateUI() {
        Debug.Log("update UI");
        for (int i = 0; i < slots.Length ; i++) {
            if (i < inventory.items.Count) {
                slots[i].AddItem(inventory.items[i]);
            } else {
                slots[i].ClearSlot();
            }
        }
    }
    public void QuitButton()
    {
        Debug.Log("Text: quit");
        Application.Quit();
    }
}
