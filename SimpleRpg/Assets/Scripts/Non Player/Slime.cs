using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy {
    public float currentHealth,maxHealth, power, toughness;
    //private float currentHealth;

    void Start() {
        currentHealth = maxHealth;
    }

    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int amountDamage) {
        currentHealth -= amountDamage;
        if(currentHealth <= 0 ) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
