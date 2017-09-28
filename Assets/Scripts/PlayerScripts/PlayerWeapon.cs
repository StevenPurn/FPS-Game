using UnityEngine;

[System.Serializable]
public class PlayerWeapon {

    public string name = "Sniper";
    public float damage = 210f;
    public float range = float.MaxValue;
    public LayerMask layerMask;
}
