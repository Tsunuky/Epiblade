using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyController : MonoBehaviour
{    
    public float LookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    CharacterStat targetStat;

    void Start() {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        targetStat  = target.GetComponent<CharacterStat>();
    }

    void Update() {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= LookRadius) {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance) {
                if (targetStat != null)
                    combat.Attack(targetStat, 0, false);
                FaceTarget();
            }
        }
    }
 
    void FaceTarget() {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookRadius);
    }
}
