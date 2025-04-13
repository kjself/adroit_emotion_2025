using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Dictionary<string, CueType> cueDict;
    private InterviewManager interviewManager;


// Start is called before the first frame update
void Start()
    {
        cueDict = new Dictionary<string, CueType>()
        {
            {"e", CueType.CLAP},
            { "r", CueType.LAUGH},
            { "t", CueType.OOH},
            { "c", CueType.GASP},
            { "v", CueType.SCREAM}
        };
        interviewManager = GetComponent<InterviewManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            foreach (KeyValuePair<string, CueType> CueDictPair in cueDict)
            {
                if (Input.GetKeyDown(CueDictPair.Key))
                {
                    interviewManager.CuePressed(CueDictPair.Value);
                    break;
                }
            }
        }
     

        foreach (KeyValuePair<string, CueType> CueDictPair in cueDict)
        {
            if (Input.GetKeyUp(CueDictPair.Key))
            {
                interviewManager.CuePressStop(CueDictPair.Value);
                break;
            }
        }
        

    }
}
