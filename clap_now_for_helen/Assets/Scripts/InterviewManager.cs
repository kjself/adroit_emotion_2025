using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewManager : MonoBehaviour
{
    Interview interview;
    float currentTime = 0;
    int currentSegmentIndex = 0;

    public InterviewManager()
    {
        var d1 = new Dialog("hello ther sis[sdf; world si and epic plaxe");
        var s1 = new InterviewSegment(d1, CueType.NONE, 0, 3);
        var d2 = new Dialog("sp thsi is seperate");
        var s2 = new InterviewSegment(d2, CueType.NONE, 3, 3);
        var d3 = new Dialog("");
        var s3 = new InterviewSegment(d1, CueType.CLAP, 6, 5);

        var sequence = new InterviewSegment[] { s1, s2, s3 };
        interview = new Interview(sequence);
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        //by setting i to the currentSegmentIndex and then setting currentSegmentIndex after means we're always incrementing
        for (int i = currentSegmentIndex; i < interview.sequence.Length; i++)
        {
            var seg = interview.sequence[i];
            if (seg.startTime <= currentTime && !seg.dialog.isPlaying)
            {
                seg.dialog.Play();
            }
            else
            {
                currentSegmentIndex = i;
                break;
            }
        }
    }
}
