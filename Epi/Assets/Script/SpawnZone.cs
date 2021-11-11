using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[System.Serializable]
public class SpawnZone : MonoBehaviour {
    public float LookRadius = 10f;
    List<GameObject> enemies = new List<GameObject>();
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject Prefab1;
    public GameObject Prefab2;
    public GameObject Prefab3;

    void Start() {
        prefabList.Add(Prefab1);
        prefabList.Add(Prefab2);
        prefabList.Add(Prefab3);

        for (; enemies.Count != 20;) {
            Vector3 position = new Vector3(Random.Range(transform.position.x - LookRadius, transform.position.x + LookRadius ), 47, Random.Range(transform.position.z - LookRadius, transform.position.z + LookRadius ));
            int prefabIndex = UnityEngine.Random.Range(0,3);
            enemies.Add(Instantiate(prefabList[prefabIndex], position, Quaternion.identity));
        }
    }

    void Update() {
        if (enemies.Count < 20) {
            for (; enemies.Count != 20;) {
                Vector3 position = new Vector3(Random.Range(transform.position.x - LookRadius, transform.position.x + LookRadius), 47, Random.Range(transform.position.z - LookRadius, transform.position.z + LookRadius ));
                int prefabIndex = UnityEngine.Random.Range(0,3);
                NavMeshHit closestHit;
                if( NavMesh.SamplePosition(  position, out closestHit, 500, 1 ) ){
                    prefabList[prefabIndex].transform.position = closestHit.position;
                    prefabList[prefabIndex].AddComponent<NavMeshAgent>();
                    enemies.Add(Instantiate(prefabList[prefabIndex], position, Quaternion.identity));
                } else{
                    Debug.Log("...");
                }
            }
        }
    }
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, LookRadius);
    }
}
