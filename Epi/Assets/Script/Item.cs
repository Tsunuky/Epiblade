using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
    new public string name = "New Item";
    public Sprite icon = null;
    public int price = 0;
    public bool isDefaultItem = false;

    public virtual void Use() {
        Debug.Log("Using "+ name);
    }

    public virtual void Buy() {
        CharacterStat s = PlayerManager.instance.player.GetComponent<CharacterStat>();
        if (s.gold >= price) {
            Debug.Log("Buy "+ name);
            s.gold -= price;
            Inventory.instance.Add(this);
        } else {
            
            Debug.Log("You don't have money");
        }
    }
    public void RemoveFromInventory() {
        if (isDefaultItem == false)
            Inventory.instance.Remove(this);
    }
}
