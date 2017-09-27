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
    }

    private void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        //do shit
    }

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
