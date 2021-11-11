using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Super Attack", menuName = "Capacity/SuperAttack")]
public class SuperAttack : Capacity {

    public int power = 0;
    public Animator animator;
    CharacterStat targetStat;

    public override void Use() {
        base.Use();
        if (lvl > 0) {
            CharacterCombat playerCombat = PlayerManager.instance.player.GetComponent<CharacterCombat>();
            Equipment weapon = EquipmentManager.instance.currentEquipement[3];
            if (weapon != null) 
                playerCombat.Attack(targetStat, power + weapon.damageModifier, true);
            else
                playerCombat.Attack(targetStat, power, true);
            animator = PlayerManager.instance.player.GetComponent<Animator>();
            animator.SetTrigger("superAttack");
        }
    }
    public void GetStat(CharacterStat Stat) {
        targetStat = Stat;
    }
    public override void LvlUp() {
        base.LvlUp();
        if (lvlup) {
            power += 3;
            lvlup = false;
        }
    }

}
