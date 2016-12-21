using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	public List<BaseStat> Stats { get; set; }
    public string ObjectSlug { get; set; } //lowercase name of the weapon

    public Item(List<BaseStat> stats, string objectSlug) {
        Stats = stats;
        ObjectSlug = objectSlug;
    }
}
