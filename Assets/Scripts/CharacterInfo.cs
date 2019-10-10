using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterInfo
{
    private string name;
    private int group;
    private Color color;
    private float x;
    private float y;
    private float z;

    public static CharacterInfo CreateFromJSON(string jsonString)
    {
        // creates CharacterInfo object 
        Debug.Log(JsonUtility.FromJson<CharacterInfo>(jsonString));
        return JsonUtility.FromJson<CharacterInfo>(jsonString);
    }
    
}
