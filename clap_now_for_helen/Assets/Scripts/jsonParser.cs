using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class jsonParser : MonoBehaviour
{
    public TextAsset jsonFile;

    string test = "{\"name\": \"Hiat\", \"age\": 1, \"cueType\": \"none\"}";

    public class TestClass
    {
        public string name;
        public int age;
        public string cueType;
    }

    void Start()
    {
        print(test);
        // Load the JSON file from the Resources folder
        //TextAsset jsonFile = Resources.Load<TextAsset>("data");

      
        if (jsonFile != null)
        {
            // Parse the JSON data
            //InterviewSegment myData = JsonUtility.FromJson<InterviewSegment>(jsonFile.text);
            TestClass myData = JsonUtility.FromJson<TestClass>(test);

            print(myData.name);
            print(myData.age);
            print(myData.cueType);
            // Use the parsed data
            //Debug.Log("Duration: " + myData.durationSeconds);
            //Debug.Log("Start time: " + myData.startTime);
            //Debug.Log("Cue type: " + myData.cueType);
        }
        else
        {
            Debug.LogError("Failed to load JSON file.");
        }
    }
}


//"duration": 3,
//    "cueType": "none",
//    "subtitle": "Our next guest– we’re dying to see him, I’m dying to get to know him, he’s trying… method acting?",
//    "audioFileName": "interview1Helen1.mp3",
//    "spriteChanges": [
//    	{"helen": "helenToCamera.png"},
//    	{ "chair": "guestChair.png"}
