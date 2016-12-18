using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    IWeapon equippedWeapon;

    CharacterStats characterStats;

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    public void EquipWeapon(Item ItemToEquip) { // Hele det her system, kan også bruges til f.eks. at equip helm
        if(EquippedWeapon != null) {

            //Fjerner Stats
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);

            //Fjerner våbnet i hånden
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }

        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapon/"+ ItemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);

        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();

        equippedWeapon.Stats = ItemToEquip.Stats;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        characterStats.AddStatBonus(ItemToEquip.Stats);

        Debug.Log(equippedWeapon.Stats[0]);
    }

    public void PerformWeaponAttack() {
        equippedWeapon.PerformAttack();
    }

}
