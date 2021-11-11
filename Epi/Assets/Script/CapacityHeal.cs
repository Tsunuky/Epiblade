using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Heal", menuName = "Capacity/Heal")]
public class CapacityHeal : Capacity {
    public int power = 0;
    public Animator animator;
    public Transform particle;

    public override void Use() {
        base.Use();
        CharacterStat player = PlayerManager.instance.player.GetComponent<CharacterStat>();
        if (lvl > 0 && player.mana >= 10) {
            player.Heal(power, HealType.Pv);
            animator = PlayerManager.instance.player.GetComponent<Animator>();
            animator.SetTrigger("magic");
            player.mana -= 10;
            Vector3 pos;
            pos.x = PlayerManager.instance.player.transform.position.x;
            pos.y = PlayerManager.instance.player.transform.position.y + (float)10.28;
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
            power += 10;
            lvlup = false;
        }
    }
}
