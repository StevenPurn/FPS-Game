using System.Collections;
using System.Collections.Generic;

public enum GameType { slayer, ctf, oddball, teamSlayer};

public class GameTypes {

    public string gameName = "Slayer";
    public GameType gameType = GameType.slayer;
    public Weapon primaryWeapon;
    public Weapon secondaryWeapon;
    public float moveSpeedMod = 1.0f;
    public float shieldMod = 1.0f;
    public float healthMod = 1.0f;
    public float jumpMod = 1.0f;
    public float damageMod = 1.0f;
    public int scoreToWin = 50;
    public int maxTeamSize = 4;
    public bool teamBased = true;
    public bool isObjective = false;

}
