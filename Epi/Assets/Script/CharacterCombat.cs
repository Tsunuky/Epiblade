using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(CharacterStat))]
public class CharacterCombat : MonoBehaviour
{
    CharacterStat myStat;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    void Start() {
        myStat = GetComponent<CharacterStat>();
    }
    void Update() {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(CharacterStat targetStat, int power, bool player) {
        if (attackCooldown <= 0) {
            targetStat.TakeDamage(myStat.damage.GetValue() + power, player);
            attackCooldown = 1f / attackSpeed;
        }
    }
}
