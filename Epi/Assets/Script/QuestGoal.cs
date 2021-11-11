using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int requireLvl;
    public Item requireItem;

    public bool IsReachedLvl() {
        CharacterStat player = PlayerManager.instance.player.GetComponent<CharacterStat>(); ;
        return (player.level.GetValue() >= requireLvl);
    }

    public bool IsReachedItem() {
        for (int i = 0; i != Inventory.instance.items.Count; i++) {
            if (Inventory.instance.items[i] == requireItem)
                return true;
        }
        return false;
    }
}

public enum GoalType {LvlNbr, PickObject, None}