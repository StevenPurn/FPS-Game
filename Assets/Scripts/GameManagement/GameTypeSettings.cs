using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTypeSettings : MonoBehaviour {

    [SerializeField]
    public static GameTypes gameType;

	// Use this for initialization
	void Start () {
        if (gameType == null)
        {
            gameType = new GameTypes();
        }
        Debug.Log("Currently playing " + gameType.gameName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveCurrentSettings()
    {
        //write current settings to JSON(?) to save them
    }

    public void LoadSettings()
    {
        //Read saved JSON files and process them as the current settings
    }
}
