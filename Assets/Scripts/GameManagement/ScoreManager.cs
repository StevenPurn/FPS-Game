using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager {

    public static Dictionary<TeamEnum.Team, int> scores = new Dictionary<TeamEnum.Team, int>();

    public static void AddTeam(TeamEnum.Team team, int score = 0)
    {
        if (scores.ContainsKey(team))
        {
            Debug.LogWarning("Tried to create a team that already exists");
            return;
        }
        else
        {
            scores.Add(team, score);
        }
    }

    public static void RemoveTeam(TeamEnum.Team team)
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

    public static void ChangeScore(TeamEnum.Team team, int score = 1)
    {
        if (scores.ContainsKey(team))
        {
            scores[team] += score;
            Debug.Log(team.ToString() + " team score: " + scores[team]);
        }
    }
}
