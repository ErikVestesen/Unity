using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
    public Item sword;
    public Item axe;

    public PlayerWeaponController playerWeaponController;


    void Start()
    {
        playerWeaponController = GetComponent<PlayerWeaponController>();

        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(6, "Power", "Your Power level"));
        sword = new Item(swordStats, "Sword");

        List<BaseStat> axeStats = new List<BaseStat>();
        axeStats.Add(new BaseStat(2, "Power", "Power level"));
        axe = new Item(axeStats, "Axe");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(sword);
        } else if(Input.GetKeyDown(KeyCode.B)) {
            playerWeaponController.EquipWeapon(axe);
        }
    }
}
