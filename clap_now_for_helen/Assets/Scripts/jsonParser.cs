
using System.Collections.Generic;

using UnityEngine;


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


    [System.Serializable]
    public class SegmentIntermediary
    {
        public int startTime;
        public float duration;
        public string cueType;
        public string subtitle;
        public string audioFileName;
        public Dictionary<string, string> spriteChanges; // An array of SpriteChange objects
    }

    public Dictionary<string, CueType> cueTypeMap;

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



        cueTypeMap = new Dictionary<string, CueType>()
        {
            {"none", CueType.NONE },
            { "clap", CueType.CLAP },
            { "laugh", CueType.LAUGH },
            { "ooh", CueType.OOH },
            { "boo", CueType.BOO },
            { "gasp", CueType.GASP },
            { "scream", CueType.SCREAM }
            // You can add more mappings here as needed
        };

        //TextAsset jsonFile = Resources.Load<TextAsset>("data");

        //var jsonFileText = json;
        var jsonFileText = jsonFile.text;
        var segStrings = jsonFileText.Trim().Split(";");
        var segments = new List<SegmentIntermediary>();
        foreach(var segString in segStrings)
        {
            segments.Add(ParseJsonToSegment(segString));
        }

        var sequence = new List<InterviewSegment>();
        foreach(var segment in segments)
        {
            sequence.Add(MapInterToFinal(segment));
        }

        //interview.sequence = sequence.TO Array()
        //print("end");

        InterviewManager.instance.interview = new Interview(sequence.ToArray());
    }

    SegmentIntermediary ParseJsonToSegment(string text)
    {
        var segment = JsonUtility.FromJson<SegmentIntermediary>(text);

        string targetKey = "\"spriteChanges\"";
        int startIndex = text.IndexOf(targetKey);
        startIndex = text.IndexOf("[", startIndex); //go to start of array

        int end = text.IndexOf("]", startIndex);//fine end of array

        //int newStart = startIndex + targetKey.Length + 1;
        var fuck = text.Substring(startIndex + 1, end - startIndex - 1);//add/sub 1 to cut out [ and ]

        //print(fuck);
        //segment.spriteChanges = JsonUtility.FromJson<Dictionary<string, string>>("{" + fuck+"}");
        var newDict = new Dictionary<string, string>();
        if(fuck != "")// there are spriteChanges (not, newDict remains empty)
        {
            
            var chargeStrings = fuck.Split(',');
            foreach (var chargeString in chargeStrings)
            {
                //print(chargeString);
                var cleanStr = chargeString.Replace("{", "").Replace("}", "").Trim();
                var dictPairStr = cleanStr.Split(':');
                newDict.Add(dictPairStr[0], dictPairStr[1]);
            }
        }
        segment.spriteChanges = newDict;
        return segment;
    }

     InterviewSegment MapInterToFinal(SegmentIntermediary segInt)
    {
        var audioFileNameNoExtension = segInt.audioFileName.Split(".")[0];
        var dialog = new Dialog(segInt.subtitle, audioFileNameNoExtension);
        var segment = new InterviewSegment(dialog, cueTypeMap[segInt.cueType], segInt.startTime, segInt.duration);

        return segment;

    }

    private string json = @"
  {
    ""startTime"": 0,
    ""duration"": 3,
    ""cueType"": ""none"",
    ""subtitle"": ""Our next guest– we’re dying to see him, I’m dying to get to know him, he’s trying… method acting?"",
    ""audioFileName"": ""interview1Helen1.mp3"",
    ""spriteChanges"": [
    	{""helen"": ""helenToCamera.png""},
    	{ ""chair"": ""guestChair.png""}
    ]
  };
{
    ""startTime"": 3,
    ""duration"": 2,
    ""cueType"": ""clap"",
    ""subtitle"": ""Geoffrey Bloom!"",
    ""audioFileName"": ""interview1Helen2.mp3"",
    ""spriteChanges"": [

        { ""helen"": ""helenHappy.png""}
    ]
  }
 
";

}
