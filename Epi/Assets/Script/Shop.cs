using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Shop : Interactable {
    public GameObject shopUI;

    public override void Interact() {
        base.Interact();
        if (Input.GetMouseButtonUp(0)) {
            shopUI.SetActive(true);
        }
    }

    public override void QuitInteract() {
        base.QuitInteract();
        shopUI.SetActive(false);
    }
    public void ClicReturn() {
        shopUI.SetActive(false);
    }
}
