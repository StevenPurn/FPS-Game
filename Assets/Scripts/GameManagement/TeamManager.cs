using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

    public static List<Teams> teams = new List<Teams>();
    static bool isRed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Teams.TeamColor SetPlayerTeam()
    {
        return Teams.TeamColor.red;
    }

    public static void AddTeam(Teams.TeamColor teamColor, int score = 0)
    {

        if (CheckIfTeamExists(teamColor))
        {
            Debug.LogWarning("Tried to create a team that already exists");
            return;
        }
        else
        {
            Teams team = new Teams();
            team.color = teamColor;
            team.score = score;
            teams.Add(team);
        }
    }

    public static bool CheckIfTeamExists(Teams.TeamColor teamColor)
    {
        bool teamExists = false;

        foreach (var team in teams)
        {
            if(team.color == teamColor)
            {
                teamExists = true;
                break;
            }
        }
        if (!teamExists)
        {
            Debug.Log("Team " + teamColor.ToString() + " doesn't exist");
        }
        else
        {
            Debug.Log("Team " + teamColor.ToString() + " exists");
        }
        return teamExists;
    }

    public static void RemoveTeam(Teams.TeamColor teamColor)
    {
        if (CheckIfTeamExists(teamColor))
        {
            foreach (var team in teams)
            {
                if(team.color == teamColor)
                {
                    teams.Remove(team);
                    return;
                }
            }
        }
        else
        {
            Debug.LogError("Tried to remove a team that didn't exist");
        }
    }

    public static void ChangeScore(Teams team, int score)
    {
        ScoreManager.ChangeScore(team, score);
        Debug.Log("Added " + score + " to " + team.color.ToString() + " team");
        Debug.Log("Score is now: " + team.score);
    }

    public static void SetPlayerTeam(Player player)
    {
        /*int smallestTeam = 900;
        Teams teamToAssign = new Teams();
        if (teams.Count > 0)
        {
            foreach (var team in teams)
            {
                if (team.players.Count < smallestTeam)
                {
                    teamToAssign = team;
                }
            }
        }
        else
        {
            teams.Add(teamToAssign);
        }*/

        Teams teamToAssign = new Teams();

        if (isRed)
        {
            teamToAssign.color = Teams.TeamColor.red;
        }
        else
        {
            teamToAssign.color = Teams.TeamColor.blue;
        }

        isRed = !isRed;

        player.teamColor = teamToAssign.color;
        teams.Add(teamToAssign);
        Debug.Log("Player: " + player.playerName + " assigned to " + player.teamColor.ToString());
    }
}
