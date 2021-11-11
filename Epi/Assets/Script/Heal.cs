using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Heal")]
public class Heal : Item {
    public int healNb;
    public HealType type;
    CharacterStat myStat;

    public override void Use() {
        base.Use();
        myStat = PlayerManager.instance.player.GetComponent<CharacterStat>();
        if (myStat.currentHealth < myStat.maxHealth && type == HealType.Pv) {
            myStat.Heal(healNb, type);
            RemoveFromInventory();
        } else if (myStat.mana < myStat.maxMana && type == HealType.Mana) {
            myStat.Heal(healNb, type);
            RemoveFromInventory();
        }
    }
}
public enum HealType {Pv, Mana}