using UnityEngine;
using System.Collections.Generic;
using System.Xml;


public class InputManager : MonoBehaviour{

    Dictionary<string, KeyCode> buttonKeys;

    private void Start()
    {

        buttonKeys = new Dictionary<string, KeyCode>();

        //read these from XML
        buttonKeys["Jump"] = KeyCode.Space;
        buttonKeys["Left"] = KeyCode.LeftArrow;
        buttonKeys["Fire1"] = KeyCode.Mouse0;
        //LoadPrefs();
    }

    //Fix this shit
    private void LoadControls()
    {
        //Actually nah, load from XML to be implemented
        Debug.Log("Controls loaded");
    }

    private void SaveControls()
    {
        //Actually nah, load from XML to be implemented
        Debug.Log("Controls saved");
    }

    private void Update()
    {
        CheckInput();
    }

    //recognize input and replace keybindings while setting new control scheme up

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
