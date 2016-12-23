using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime : MonoBehaviour, IEnemy {
    public float currentHealth,maxHealth, power, toughness;
    //private float currentHealth;

    public Slider healthbar;


    void Start() {
        currentHealth = maxHealth;
        healthbar.value = CalculateHealth();
    }

    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int amountDamage) {
        currentHealth -= amountDamage;
        healthbar.value = CalculateHealth();
        if (currentHealth <= 0 ) {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }
}
