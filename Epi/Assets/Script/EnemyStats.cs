using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStats : CharacterStat {
    
    public Transform explosion;
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;
    public override void Die() {
        base.Die();
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);
        if(explosion) {
            GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
            Destroy(exploder, 2.0f);
        }
        CharacterStat pl = PlayerManager.instance.player.GetComponent<CharacterStat>();
        int xp = level.GetValue() * 30;
        pl.GainXP(xp);
        pl.gold += level.GetValue() * 60;
        int prefabIndex = UnityEngine.Random.Range(0,3);
        Instantiate(prefabList[prefabIndex], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
