using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Crystal : Interactable {
    
    public GameObject crystal;
    public bool pick;
    public override void Interact() {
        base.Interact();
        if (Input.GetMouseButtonUp(0) && pick == false)
            onClickCrystal();
    }

    public override void QuitInteract() {
        base.QuitInteract();
    }

    public void onClickCrystal() {
        pick = true;
        Vector3 pos;
        pos.x = transform.position.x;
        pos.y = 89;
        pos.z = 928;
        Instantiate(crystal, pos, Quaternion.identity);
    }
}
