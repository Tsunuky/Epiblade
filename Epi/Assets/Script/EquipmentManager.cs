using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    
    void Awake()
    {
        instance = this;
    }
    #endregion
    public Equipment[] currentEquipement;
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    Inventory inventory;
    void Start() {
        inventory = Inventory.instance;
        int numSlot = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipement = new Equipment[numSlot];
    }

    public void Equip(Equipment newItem) {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;

        if (currentEquipement[slotIndex] != null) {
            oldItem = currentEquipement[slotIndex];
            inventory.Add(oldItem);
        } if (onEquipmentChanged != null) {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        currentEquipement[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex) {
        if (currentEquipement[slotIndex] != null) {
            Equipment oldItem = currentEquipement[slotIndex];
            inventory.Add(oldItem);
            currentEquipement[slotIndex] = null;
            if (onEquipmentChanged != null) {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }
    public void UnequipAll() {
        for (int i = 0; i != currentEquipement.Length; i++)
            Unequip(i);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
}
