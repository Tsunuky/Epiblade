using UnityEngine;

[System.Serializable]
public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact() {
        base.Interact();
        Pickup();
    }

    void Pickup() {
        print("it's pick  " + item.name);
        bool itPicked = Inventory.instance.Add(item);
        if (itPicked)
            Destroy(gameObject);
    }
}
