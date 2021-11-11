using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class StatMenu : MonoBehaviour
{
    public Text LvlText;
    public Text damageText;
    public Text armorText;
    public Text PointText;
    public Text GoldText;
    CharacterStat stat;

    void Start() {
        stat = PlayerManager.instance.player.GetComponent<CharacterStat>();
        LvlText.text = "Lvl: " + stat.level.GetValue().ToString();
        damageText.text = "Damage: " + stat.damage.GetValue().ToString();
        armorText.text = "Armor: " + stat.armor.GetValue().ToString();
        PointText.text = "Capacity Point: " + stat.capacityPoint.ToString();
        GoldText.text = "Gold: " + stat.gold.ToString();
    }

    void Update() {
        LvlText.text = "Lvl: " + stat.level.GetValue().ToString();
        damageText.text = "Damage: " + stat.damage.GetValue().ToString();
        armorText.text = "Armor: " + stat.armor.GetValue().ToString();
        PointText.text = "Capacity Point: " + stat.capacityPoint.ToString();
        GoldText.text = "Gold: " + stat.gold.ToString();
    }
}
