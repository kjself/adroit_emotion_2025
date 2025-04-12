using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private CueType cue;
    //private Dictionary<string, CueType> cueDict;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            if(Input.GetKeyDown("e"))
            {
                cue = CueType.CLAP;
            }
            if(Input.GetKeyDown("r"))
            {
                cue = CueType.LAUGH;
            }
            if (Input.GetKeyDown("t"))
            {
                cue = CueType.IMPRESSED;
            }
            if (Input.GetKeyDown("c"))
            {
                cue = CueType.GASP;
            }
            if (Input.GetKeyDown("v"))
            {
                cue = CueType.SCREAM;
            }
        }

    }
    public CueType getCue()
    {
        return cue;
    }

}
