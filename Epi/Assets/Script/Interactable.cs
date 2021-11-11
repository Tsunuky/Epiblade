using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    //public float attackDamage;
    bool isFocus = false;
    Transform player;
    bool hasInteract = false;
    public float Speed = 0.19f;
    public float Cooldown = 0f;
    public Transform interactionTransform;

    void Start() {
        player = PlayerManager.instance.player.transform;
        Debug.Log(player.position);
    }
    public virtual void Interact() {
        Debug.Log("Interacting with" + transform.name);
    }
    public virtual void QuitInteract() {
        Debug.Log("Stop interacting with" + transform.name);
    }
    void Update() {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius) {
                Interact();
                hasInteract = true;
            }
            if (distance > radius && hasInteract) {
                QuitInteract();
                hasInteract = false;
            }
            Cooldown -= Time.deltaTime;
    }
    public void OnFocused(Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
        hasInteract = false;
    }
    public void onDefocused() {
        isFocus = false;
        player = null;
    }
    void OnDrawGizmosSelected() {
        if (interactionTransform == null)
            interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
