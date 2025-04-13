using Palmmedia.ReportGenerator.Core.Common;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Text.Json;
using static UnityEditor.Progress;
using System.Text.RegularExpressions;

[System.Serializable]
public class jsonParser : MonoBehaviour
{
    public TextAsset jsonFile;

    string test0 = @" {
    ""startTime"": 0,
    ""duration"": 3,
    ""cueType"": ""none"",
    ""subtitle"": ""Our next guest– we’re dying to see him, I’m dying to get to know him, he’s trying… method acting?"",
    ""audioFileName"": ""interview1Helen1.mp3"",
    ""spriteChanges"": [
    	{""helen"": ""helenToCamera.png""},
    	{""chair"": ""guestChair.png""}
    ]
  }
";



    public class TestClass
    {
        public string name;
        public int age;
        public string cueType;
        public TestClass2[] spriteChanges;
    }

    public class TestClass2
    {
        public string helen;
        public string chair;


    }

    public class Test3

    {
        public Dictionary<string, string> dict;
    }

    public class SegmentIntermediary
    {
        public float startTime;
        public float duration;
        public string cueType;
        public string subtitle;
        public string audioFileName;
        //public TestClass2[] spriteChanges;
    }

    [System.Serializable]
    public class SpriteChange
    {
        public string helen;
        public string chair;
    }

    [System.Serializable]
    public class InterviewData
    {
        public int startTime;
        public float duration;
        public string cueType;
        public string subtitle;
        public string audioFileName;
        public Dictionary<string, string> spriteChanges; // An array of SpriteChange objects
    }


    void Start()
    {
        //print(test);
        // Load the JSON file from the Resources folder
        //TextAsset jsonFile = Resources.Load<TextAsset>("data");
        //List<Item> items = JsonConvert.DeserializeObject<List<Item>>(test);
        //TestClass? weatherForecast = await JsonSerializer.
        //    DeserializeAsync<TestClass>(test);.
        //var bob = new TestClass();
        //bob.name = "jim";
        //bob.age = 2;
        //bob.cueType = "spdfoj";
        //bob.spriteChanges = new TestClass2[];
        //bob.spriteChanges.changeGuy = "pain";
        //var str = JsonUtility.ToJson(bob);
        //print(str);


        var segment = JsonUtility.FromJson<InterviewData>(test0);

        string targetKey = "\"spriteChanges\"";
        int startIndex = test0.IndexOf(targetKey);
        startIndex = test0.IndexOf("[", startIndex); //go to start of array

        int end = test0.IndexOf("]", startIndex);//fine end of array

        //int newStart = startIndex + targetKey.Length + 1;
        var fuck = test0.Substring(startIndex + 1, end - startIndex - 1);//add/sub 1 to cut out [ and ]

        //print(fuck);
        //segment.spriteChanges = JsonUtility.FromJson<Dictionary<string, string>>("{" + fuck+"}");

        var chargeStrings = fuck.Split(',');
        var newDict = new Dictionary<string, string>();
        foreach (var chargeString in chargeStrings)
        {
            //print(chargeString);
            var cleanStr = chargeString.Replace("{", "").Replace("}", "").Trim();
            var dictPairStr = cleanStr.Split(':');
            newDict.Add(dictPairStr[0], dictPairStr[1]);
        }

        segment.spriteChanges = newDict;

        //print("end");
    }
}
