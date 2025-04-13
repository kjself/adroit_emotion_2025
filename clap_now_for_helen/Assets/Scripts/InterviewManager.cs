using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewManager : MonoBehaviour
{
    Interview interview;
    float currentTime = 0;
    int nextSegmentIndex = 0;
    CueType activeCue = CueType.NONE;

    public AnimationCurve curve;

    public InterviewManager()
    {
        var d1 = new Dialog("1st");
        var s1 = new InterviewSegment(d1, CueType.NONE, 0, 3);
        var d2 = new Dialog("2 hi ther");
        var s2 = new InterviewSegment(d2, CueType.NONE, 3, 5);
        var d3 = new Dialog("");
        var s3 = new InterviewSegment(d3, CueType.CLAP, 8, 5);
        var d4 = new Dialog("4 start again!!!");
        var s4 = new InterviewSegment(d4, CueType.NONE, 13, 5);

        var sequence = new InterviewSegment[] { s1, s2, s3, s4 };
        interview = new Interview(sequence);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        for (int i = nextSegmentIndex; i < interview.sequence.Length; i++)
        {
        
            var seg = interview.sequence[i];
            if (seg.startTime <= currentTime && !seg.dialog.isPlaying)
            {
                seg.dialog.Play();
                nextSegmentIndex = i+1;
            }
            else
            {
                break;
            }
        }

        if (activeCue != CueType.NONE)
        {
            var currentSegment = interview.sequence[nextSegmentIndex-1];
            Score(currentSegment);
        }

    }
    public void CuePressed(CueType cueType)
    {
        if(activeCue == CueType.NONE)//eligible to be set
        {
            SetCueDisplay(cueType);
            PlayCueAudio(cueType);
            activeCue = cueType;
            //Debug.Log(cueType + " Button Down");

        }

    }

    public void CuePressStop(CueType cueType)
    {
        if (activeCue == cueType)
        {
            SetCueDisplay(CueType.NONE);
            PlayCueAudio(cueType);
            activeCue= CueType.NONE;
            //Debug.Log(cueType + " Button Up");
        }
    }

    //this could fail if CueDisplay is already set
    private bool SetCueDisplay(CueType cueType)
    {
        //maybe dont do this
        //check if cueDisplay.text == "" 
        //then set
        //else return error
        //Debug.Log("Displaying Cue");
        return true;
    }

    private void PlayCueAudio(CueType cueType)
    {
        //Debug.Log("Playing Cue Audio");

    }

    private void Score(InterviewSegment segment)
    {
        //Debug.Log("Seg: " + segment.cueType + " "+segment.dialog.subtitle);
        if(activeCue== segment.cueType)
        {
            var curveHeight = curve.Evaluate((currentTime - segment.startTime) / segment.durationSeconds);
            GameManager.instance.score += curveHeight * Time.deltaTime;
        }
        //Debug.Log("Score: " + GameManager.instance.score);
    }
        
}
