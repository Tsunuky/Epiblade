using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Defance Up", menuName = "Capacity/DefUp")]
public class DefanceUp : Capacity {
    public int power = 0;
    public Animator animator;
    public Transform particle;
    public bool activate;

    public override void Use() {
        base.Use();
        CharacterStat playerStat = PlayerManager.instance.player.GetComponent<CharacterStat>();
        if (lvl > 0 && playerStat.mana >= 6) {
            playerStat.armor.baseValue += power;
            activate = true;
            animator = PlayerManager.instance.player.GetComponent<Animator>();
            animator.SetTrigger("magic");
            playerStat.mana -= 6;
            Vector3 pos;
            pos.x = PlayerManager.instance.player.transform.position.x;
            pos.y = PlayerManager.instance.player.transform.position.y + 2.28f;
            pos.z = PlayerManager.instance.player.transform.position.z;
            Quaternion rot = Quaternion.identity;
            rot.x = 0;
            rot.y = 0;
            rot.z = 0;
            if(particle) {
                GameObject exploder = ((Transform)Instantiate(particle, pos, rot)).gameObject;
                Destroy(exploder, 2.0f);
            }
        }
    }
    public override void LvlUp() {
        base.LvlUp();
        if (lvlup) {
            power += 2;
            lvlup = false;
        }
    }
}
