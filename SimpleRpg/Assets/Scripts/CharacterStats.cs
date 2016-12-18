﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    public List<BaseStat> stats = new List<BaseStat>();

    void Start() {
        stats.Add(new BaseStat(4,"Power", "Your power level"));
        stats[0].AddStatBonus(new StatBonus(5));
        stats[0].AddStatBonus(new StatBonus(5));
        stats[0].RemoveStatBonus(new StatBonus(-3));
        Debug.Log("Power: " + stats[0].GetCalculatedStatValue());
    }

    public void AddStatBonus(List<BaseStat> statBonuses) {
        foreach(BaseStat statBonus in statBonuses) {
            stats.Find(x => x.StatName == statBonus.StatName );
        }
    }



}
