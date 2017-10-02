using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager {

    public static Dictionary<Teams.TeamColor, int> scores = new Dictionary<Teams.TeamColor, int>();

    public static void AddTeam(Teams.TeamColor team, int score = 0)
    {
        if (scores.ContainsKey(team))
        {
            Debug.LogWarning("Tried to create a team that already exists");
            return;
        }
        else
        {
            scores.Add(team, score);
            Debug.Log(team.ToString() + " added to scoremanager");
        }
    }

    //Shouldn't remove team, maybe add state for inactive if all players have left?
    public static void RemoveTeam(Teams.TeamColor team)
    {
        if (scores.ContainsKey(team))
        {
            scores.Remove(team);
        }
        else
        {
            Debug.LogError("Tried to remove a team that didn't exist");
        }
    }

    public static void ChangeScore(Teams team, int score = 1)
    {
        if (TeamManager.teams.Contains(team))
        {
            team.score += score;
            Debug.Log(team.color.ToString() + " team score: " + team.score);
            CheckForWin(team);
        }
    }

    public static void CheckForWin(Teams team)
    {
        if(team.score >= GameTypeSettings.gameType.scoreToWin)
        {
            Debug.Log(team.color.ToString() + " won!");
        }
    }

    public static void ChangeScore(Teams.TeamColor teamColor, int score = 1)
    {
        if (TeamManager.CheckIfTeamExists(teamColor))
        {
            foreach (var team in TeamManager.teams)
            {
                if(team.color == teamColor)
                {
                    ChangeScore(team, score);
                }
            }
        }
    }
}
