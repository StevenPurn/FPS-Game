using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : NetworkBehaviour {

    [SerializeField]
    private Camera cam;

    private const string playerTag = "Player";
    private PlayerController player;
    private Teams.TeamColor team;

    InputManager inputManager;
    public Weapon weapon;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("Playershoot: No camera referenced on playerWeapon");
        }

        player = GetComponent<PlayerController>();
        team = player.GetTeam();
        inputManager = FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void Update () {
        CheckTarget();
        CheckInput();
	}

    void CheckInput()
    {
        if (weapon.canShoot)
        {
            if (inputManager.GetButtonDown("Fire1"))
            {
                Shoot();
            }
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

    [Client]
    void CheckTarget()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, weapon.layerMask))
        {
            if (hit.collider.GetComponent<PlayerController>() != null)
            {
                if(hit.collider.GetComponent<PlayerController>().GetTeam() != team)
                {
                    //Change reticule to red
                    SetReticuleColor(Color.red);
                }
                else if(hit.collider.GetComponent<PlayerController>().GetTeam() == team)
                {
                    //Change reticule to green
                    SetReticuleColor(Color.green);
                }
            }
            else
            {
                SetReticuleColor(Color.white);
            }
        }
        else
        {
            SetReticuleColor(Color.white);
        }
    }

    [Client]
    private void SetReticuleColor(Color col)
    {
        GameObject.Find("Reticule").GetComponent<Image>().color = col;
    }

    [Command]
    void CmdPlayerShot(string playerID)
    {
        Debug.Log(playerID + " has been shot");
        //Find player with matching id and send information about damage
        PlayerController playerCon = GameObject.Find(playerID).GetComponent<PlayerController>();
        bool killedPlayer = playerCon.TakeDamage(weapon.damage, weapon);
        if (GameTypeSettings.gameType.gameType == GameType.slayer)
        {
            if (killedPlayer && playerCon.GetTeam() != team)
            {
                ScoreManager.ChangeScore(team);
            }
            else
            {
                ScoreManager.ChangeScore(team, -1);
            }
        }
    }
}
