using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[RequireComponent(typeof(CharacterStat))]
public class Enemy : Interactable {
    PlayerManager playerManager;
    CharacterStat myStat;

    //void Start() {
        //playerManager = PlayerManager.instance;
        //myStat = GetComponent<CharacterStat>();
    //}
    public override void Interact() {
        base.Interact();
        playerManager = PlayerManager.instance;
        myStat = GetComponent<CharacterStat>();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        PlayerStats stats = playerManager.player.GetComponent<PlayerStats>();
        Equipment weapon = EquipmentManager.instance.currentEquipement[3]; 
        //Weapon myWeapon = playerManager.player.Hand.GetComponent<Weapon>();
        if (playerCombat != null && Input.GetMouseButtonUp(0) && weapon != null)
            playerCombat.Attack(myStat, weapon.damageModifier, true);
        if (playerCombat != null && Input.GetMouseButtonUp(0) && weapon == null)
            playerCombat.Attack(myStat, 0, true);
        if (playerCombat != null && Input.GetKey(KeyCode.F) && Cooldown <= 0) {
            stats.superAttack.GetStat(myStat);
            stats.superAttack.Use();
            Cooldown = 1f / Speed;
        }
    }
    public override void QuitInteract() {
        base.QuitInteract();
    }
}
