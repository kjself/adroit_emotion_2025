using System.Collections.Generic;

public class InterviewSegment
{
    public Dialog dialog;
    public CueType cueType;
    public float startTime; 
    public float durationSeconds;
    public Dictionary<string, string> spriteChanges;

    public InterviewSegment(Dialog dialog, CueType cueType, float startTime, float duration)
    {
        this.dialog = dialog;
        this.cueType = cueType;
        this.startTime = startTime;
        this.durationSeconds = duration;
    }

}
