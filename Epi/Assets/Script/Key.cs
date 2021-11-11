using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Holy Key", menuName = "Inventory/Key")]
public class Key : Item {

    public override void Use() {
        base.Use();
        Destroy(PrisonManager.instance.prison);
        isDefaultItem = false;
        RemoveFromInventory();
    }
}
