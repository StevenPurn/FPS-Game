using UnityEngine.Networking;
using UnityEngine;

public class PlayerShoot : NetworkBehaviour {

    [SerializeField]
    private Camera cam;

    private const string playerTag = "Player";

    InputManager inputManager;
    public PlayerWeapon weapon;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("No camera referenced on playerWeapon");
        }

        inputManager = FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void Update () {
        CheckInput();
	}

    void CheckInput()
    {
        if (inputManager.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    [Client]
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, weapon.layerMask))
        {
            if(hit.collider.tag == playerTag)
            {
                CmdPlayerShot(hit.collider.name);
            }
        }
    }

    [Command]
    void CmdPlayerShot(string playerID)
    {
        Debug.Log(playerID + " has been shot");
    }
}
