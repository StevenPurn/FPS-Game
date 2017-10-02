using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon {

    public string name = "Sniper";
    public float damage = 210f;
    public float range = float.MaxValue;
    public LayerMask layerMask;
    public float fireDelay = 0.5f;
    public bool canShoot = true;
    public bool isAutomatic;

    Weapon (string _name, float _damage, float _range, float _fireDelay, bool _isAutomatic = false)
    {
        name = _name;
        damage = _damage;
        range = _range;
        fireDelay = _fireDelay;
        isAutomatic = _isAutomatic;
    }

    private void SetCanShoot(bool _canShoot)
    {
        canShoot = _canShoot;
    }
}
