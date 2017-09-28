using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayerWeapon {

    public string name = "Sniper";
    public float damage = 210f;
    public float range = float.MaxValue;
    public LayerMask layerMask;
    public float fireDelay = 0.5f;
    public bool canShoot = true;

    public System.Collections.Generic.IEnumerable<IEnumerable> ResetNextFireTime()
    {
        /*
        yield return new WaitForSeconds(fireDelay);
        SetCanShoot(true);
        */

        IEnumerable<IEnumerable> enumerable = null;
        SetCanShoot(true);
        return enumerable;
    }

    private void SetCanShoot(bool _canShoot)
    {
        canShoot = _canShoot;
    }
}
