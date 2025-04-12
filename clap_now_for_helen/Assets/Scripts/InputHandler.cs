using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Dictionary<string, CueType> cueDict;



// Start is called before the first frame update
void Start()
    {
        cueDict = new Dictionary<string, CueType>()
        {
            {"e", CueType.CLAP},
            { "r", CueType.LAUGH},
            { "t", CueType.IMPRESSED},
            { "c", CueType.GASP},
            { "v", CueType.SCREAM}
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            foreach (KeyValuePair<string, CueType> CueDictPair in cueDict)
            {
                if (Input.GetKeyDown(CueDictPair.Key))
                {
                    InterviewManager.CuePressed(CueDictPair.Value);
                    break;
                }
            }
        }

    }
}
