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

    string test = "{\"name\": \"Hiat\", \"age\": 1, \"cueType\": \"none\", \"spriteChanges\": [{\"changeGuy\": \"spriteName\"}, {\"changeGuy\": \"Podboy\"}]}";
    string test1 = "{\"a1\":[1,2,3,5]}";


    public class TestClass
    {
        public string name;
        public int age;
        public string cueType;
        public TestClass2[] spriteChanges;
    }

    public class TestClass2
    {
        public string changeGuy;

    }
    
    public class Test3
   
    {
        public int[] a1;
    }
    void Start()
    {
        print(test);
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



        TestClass myData = JsonUtility.FromJson<TestClass>(test);

        string targetKey = "\"spriteChanges\"";
        int startIndex = test.IndexOf(targetKey);
        startIndex = test.IndexOf("[", startIndex); //go to start of array

        int end = test.IndexOf("]", startIndex);//fine end of array

        //int newStart = startIndex + targetKey.Length + 1;
        var fuck = test.Substring(startIndex+1, end - startIndex-1);//add/sub 1 to cut out [ and ]

        print(fuck);

        var chargeStrings= fuck.Split(',');
        List<TestClass2> smallMan = new List<TestClass2>();
        foreach (var chargeString in chargeStrings)
        {
        print(chargeString);
        smallMan.Add(JsonUtility.FromJson<TestClass2>(chargeString));

        }



        print(smallMan);
        myData.spriteChanges = smallMan.ToArray();

        print("end");
        //var myarrayData = JsonUtility.FromJson<Test3>(test1);
        //foreach(var item in myarrayData.a1)
        //{
        //print(item);

        //}

        //if (jsonFile != null)
        //{
        //    // Parse the JSON data
        //    //InterviewSegment myData = JsonUtility.FromJson<InterviewSegment>(jsonFile.text);
        //    //TestClass myData = JsonUtility.FromJson<TestClass>(test);

        //    print(myData.name);
        //    print(myData.age);
        //    print(myData.cueType);
        //    print(myData.spriteChanges[0]);
        //    print(myData.spriteChanges[1]);

        //    // Use the parsed data
        //    //Debug.Log("Duration: " + myData.durationSeconds);
        //    //Debug.Log("Start time: " + myData.startTime);
        //    //Debug.Log("Cue type: " + myData.cueType);
        //}
        //else
        //{
        //    Debug.LogError("Failed to load JSON file.");
        //}
    }
}


//"duration": 3,
//    "cueType": "none",
//    "subtitle": "Our next guest– we’re dying to see him, I’m dying to get to know him, he’s trying… method acting?",
//    "audioFileName": "interview1Helen1.mp3",
//    "spriteChanges": [
//    	{"helen": "helenToCamera.png"},
//    	{ "chair": "guestChair.png"}
