using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime : MonoBehaviour, IEnemy {
    public float currentHealth,maxHealth, power, toughness;
    //private float currentHealth;

    public Slider healthbar;
    public Text healthName;

    void Start() {
        currentHealth = maxHealth;

        healthbar.value = CalculateHealth();
        healthbar.gameObject.SetActive(false);

        healthName.text = this.name;
        healthName.gameObject.SetActive(false);
    }

    void OnMouseOver()
    {

        healthName.gameObject.SetActive(true);
        healthbar.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        healthName.gameObject.SetActive(false);
        healthbar.gameObject.SetActive(false);
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
        healthName.gameObject.SetActive(false);
        healthbar.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }
}
