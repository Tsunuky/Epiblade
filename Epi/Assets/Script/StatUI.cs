using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StatUI : MonoBehaviour
{
    public Text HealthText;
    public Text ManaText;
    public Text ExpText;
    CharacterStat stat;

    void Start() {
        stat = PlayerManager.instance.player.GetComponent<CharacterStat>();
        HealthText.text = "Health: " + stat.currentHealth.ToString() + "/" + stat.maxHealth.ToString();
        ManaText.text = "Mana: " + stat.mana.ToString() + "/" + stat.maxMana.ToString();
        ExpText.text = "Exp: " + stat.exp.GetValue().ToString() + "/" + (200 * stat.level.GetValue()).ToString();
    }

    void Update() {
        HealthText.text = "Health: " + stat.currentHealth.ToString() + "/" + stat.maxHealth.ToString();
        ManaText.text = "Mana: " + stat.mana.ToString() + "/" + stat.maxMana.ToString();
        ExpText.text = "Exp: " + stat.exp.GetValue().ToString() + "/" + (200 * stat.level.GetValue()).ToString();
    }
}
