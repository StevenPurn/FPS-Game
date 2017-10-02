using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class WeaponManager : MonoBehaviour {

    public static List<Weapon> weapons;
    public static string weaponDataFileLocation = "Weapons.xml";

    private void Start()
    {
        //GetWeaponsFromFile();
    }

    public static void GetWeaponsFromFile()
    {
        weapons = XMLHelper.LoadFromXML<List<Weapon>>(weaponDataFileLocation);
    }
}
