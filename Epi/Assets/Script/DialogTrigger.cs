using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogTrigger : Interactable
{
    public Dialog dialog;
    public GameObject dialogWindow;

    public override void Interact() {
        base.Interact();
        if (Input.GetMouseButtonUp(0)) {
            TriggerDialog();
            dialogWindow.SetActive(true);
        }
    }

    public override void QuitInteract() {
        base.QuitInteract();
    }
    public void TriggerDialog() {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
}
