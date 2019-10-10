using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadData : MonoBehaviour
{
    private string jsonFile = "lesmis-3d.json";
    // Start is called before the first frame update
    void Start()
    {
        LoadJsonData();
    }

    // Update is called once per frame
    private void LoadJsonData()
    {
        string fPath = Path.Combine(Application.dataPath, jsonFile);
        
        if (File.Exists(fPath))
        {
            
            // read JSON file
            string JSONData = File.ReadAllText(fPath);
            // create Character Info objects
            CharacterInfo loadedInfo = CharacterInfo.CreateFromJSON(JSONData);
            
            // create relationship objects
        }
        else
        {
            Debug.Log("File does not exist");
        }
    }
}
