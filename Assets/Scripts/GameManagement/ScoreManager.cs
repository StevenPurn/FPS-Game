using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager {

    /*public static void AddTeam(Teams.TeamColor team, int score = 0)
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
    }*/

    //Shouldn't remove team, maybe add state for inactive if all players have left?
    public static void DeactivateTeam(Teams team)
    {
        if(team.players.Count <= 0)
        {
            team.SetActive(false);
            //Grey out team name on scoreboard
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
            //Reset game type and scores
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
