using UnityEngine;
using System.Collections.Generic;


public class InputManager : MonoBehaviour{

    Dictionary<string, KeyCode> buttonKeys;

    private void Start()
    {
        buttonKeys = new Dictionary<string, KeyCode>();

        //read these from user prefs
        buttonKeys["Jump"] = KeyCode.Space;
        buttonKeys["Left"] = KeyCode.LeftArrow;
        buttonKeys["Fire1"] = KeyCode.Mouse0;
        //  LoadPrefs();
    }

    //Fix this shit
    private void LoadPrefs()
    {
        foreach(var key in buttonKeys)
        {
            if(PlayerPrefs.GetString(key.Key) != null)
            {
                //buttonKeys[key.Key] = PlayerPrefs.GetString(key.Key);
            }
        }
        Debug.Log("PlayerPrefs loaded");
    }

    private void SavePrefs()
    {
        foreach (var key in buttonKeys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }

    private void Update()
    {
        CheckInput();
    }

    //recognize input and replace keybindings

    void CheckInput()
    {
        //do shit
    }
    
    //respond to playerinput during the game
    public bool GetButtonDown(string buttonName)
    {
        if(buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("Error: no button found");
            return false;
        }

        return Input.GetKeyDown(buttonKeys[buttonName]);
    }
}
