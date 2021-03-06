﻿using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    public float maxHealth = 100f;
    public float health;
    public float maxShield = 100f;
    public float shield;
    public Player player;

	// Use this for initialization
	void Start ()
    {
        player = new Player();
        motor = GetComponent<PlayerMotor>();
        health = maxHealth;
        shield = maxShield;
        TeamManager.SetPlayerTeam(player);
        //ScoreManager.AddTeam(player.teamColor);
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleInput();
	}

    public void SetTeam(Teams.TeamColor _team)
    {
        player.teamColor = _team;
    }

    public Teams.TeamColor GetTeam()
    {
        return player.teamColor;
    }

    //Movement/aiming
    private void HandleInput()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * moveSpeed;

        motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        float camRotation = xRot * lookSensitivity;

        motor.RotateCamera(camRotation);

    }

    public bool TakeDamage(float amount, Weapon weapon)
    {
        if(amount > shield)
        {
            shield = 0;
            health -= amount;
            if(health <= 0)
            {
                Die(weapon);
                return true;
            }
        }
        else
        {
            shield -= amount;
        }
        return false;
    }

    public void Die(Weapon weapon)
    {
        //Die and generate ragdoll
        Debug.Log(gameObject.name + " has been killed using " + weapon.name);
    }
}
