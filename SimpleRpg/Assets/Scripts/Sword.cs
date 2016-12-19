using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public List<BaseStat> Stats { get; set;}

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.name);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Stopped hitting" + other.name);
    }

    
}
