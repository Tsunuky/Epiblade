using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[System.Serializable]
public class Walk : MonoBehaviour
{
    public Animator animator;
    
    public bool isGrounded;

    float HSpeed = 0.10f;
    public float timeRemaining = 10;
    float HCooldown = 0f;
    
    float DSpeed = 0.05f;
    float DCooldown = 0f;
    PlayerStats pl;
    void Start() {
        pl = PlayerManager.instance.player.GetComponent<PlayerStats>();
    }

    void Update() {
        DCooldown -= Time.deltaTime;
        HCooldown -= Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("walk", true);
        } else {
            animator.SetBool("walk", false);
        }
        
                
        if (Input.GetKey(KeyCode.H) && HCooldown <= 0) {
            pl.HealPv.Use();
            HCooldown = 1f / HSpeed;
        }

        if (Input.GetKey(KeyCode.G) && DCooldown <= 0) {
            pl.DefUp.Use();
            DCooldown = 1f / DSpeed;
        }

        if (timeRemaining > 0 && pl.DefUp.activate)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining <= 0 && pl.DefUp.activate)
        {
            CharacterStat s = PlayerManager.instance.player.GetComponent<CharacterStat>();
            pl.DefUp.activate = false;
            timeRemaining = 10f;
            s.armor.baseValue -= pl.DefUp.power;
        }

        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("attack");
        }
        if (Input.GetButtonDown("Jump") && isGrounded) {
            animator.SetTrigger("jump");
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("idle", true);
        } else {
            animator.SetBool("idle", false);
        }
    }
}
