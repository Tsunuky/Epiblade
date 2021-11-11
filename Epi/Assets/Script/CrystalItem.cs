using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Crystal", menuName = "Inventory/Crystal")]
public class CrystalItem : Item {

    public Item sword_final;
    public override void Use() {
        base.Use();
        isDefaultItem = false;
        RemoveFromInventory();
        Inventory.instance.Add(sword_final);
    }
}
