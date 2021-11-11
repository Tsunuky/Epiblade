using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyHealth : MonoBehaviour
{
    public float MaxHealth;
    public float Health;
    public heath_bar health_bar;
    public Transform explosion;
    //public ParticleEffect prefabParticle;

    //private GameObject instantiatedParticle;
    void Start() {
        health_bar.SetMaxHealth(MaxHealth);
    }
    public void TakeDammage(float dam) {
        Health -= dam;
        health_bar.SetHealth(Health);
        if (Health <= 0) {
            Die();
            print("he died");
        }
    }

    private void Die(){
        if(explosion) {
            GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
            Destroy(exploder, 2.0f);
        }
        Destroy(gameObject);

    }
}
