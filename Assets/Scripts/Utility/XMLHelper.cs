using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;

public class XMLHelper
{
    public enum DataToLoad { gameTypes, weaponData };

    private static string filepath = Application.dataPath + "/Data/";

    public static T LoadFromXML<T>(string fileLocation)
    {
        Debug.Log("Attempting to load XML from: " + filepath + fileLocation);
        var serializer = new XmlSerializer(typeof(T));
        using (var stream = new StreamReader(filepath + fileLocation))
        {
            object obj = serializer.Deserialize(stream);
            return (T)obj;
        }
    }

    void SaveToXML(object obj, bool appendFile = false)
    {
        var serializer = new XmlSerializer(obj.GetType());

        using (var stream = new StreamWriter(Application.dataPath + filepath, appendFile))
        {
            serializer.Serialize(stream, obj);

        }
        Debug.Log("Saved Some text");
    }

    public void SaveData()
    {
        //SaveToXML();
    }

    /*public string LoadData(string fileLocation, DataToLoad data)
    {
        string text;

        switch (data)
        {
            case DataToLoad.gameTypes:
                text = LoadFromXML<GameTypes>(fileLocation);
                break;
            case DataToLoad.weaponData:
                text = LoadFromXML<Weapons>(fileLocation);
                break;
        }
        string text = LoadFromXML<GameTypes>(fileLocation);
        Debug.Log("Loaded Some text");
        return text;
    }*/
}