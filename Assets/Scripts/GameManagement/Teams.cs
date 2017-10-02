using System.Collections.Generic;

public class Teams {
    
    public enum TeamColor { red, blue, orange, yellow, green, purple };
    public List<Player> players = new List<Player>();
    public TeamColor color = TeamColor.red;
    public int score;
    public bool isActive;

    public void SetActive(bool active)
    {
        isActive = active;
    }
}
