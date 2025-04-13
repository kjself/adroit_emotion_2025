using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterviewManager : MonoBehaviour
{
    Interview interview;
    float currentTime = 0;
    int nextSegmentIndex = 0;
    CueType activeCue = CueType.NONE;
    public TMP_Text cueDisplay;

    public AnimationCurve curve;

    [SerializeField]
    private Sprite h1;
    [SerializeField]
    private Sprite h2;
    public Sprite g1;
    public Sprite g2;

    Dialog[] d = new Dialog[4];
    InterviewSegment[] s = new InterviewSegment[4];

    public InterviewManager()
    {
        d[0] = new Dialog("1st");
        s[0] = new InterviewSegment(d[0], CueType.NONE, 0, 3);
        d[1] = new Dialog("2 hi ther");
         s[1] = new InterviewSegment(d[1], CueType.NONE, 3, 5);
         d[2] = new Dialog("");
         s[2] = new InterviewSegment(d[2], CueType.CLAP, 8, 5);
        d[3] = new Dialog("4 start again!!!");
        s[3] = new InterviewSegment(d[3], CueType.NONE, 13, 5);

    }

    private void Start()
    {
        s[0].spriteChanges = new Dictionary<string, Sprite>()
        {
            {"Helen", h1},
            {"Guest",  g1}
        };

        s[1].spriteChanges = new Dictionary<string, Sprite>()
        {
            {"Helen", h2},
            {"Guest",  g2}

        };
        s[2].spriteChanges = new Dictionary<string, Sprite>()
        {
            {"Helen", h1}
        };
        s[3].spriteChanges = new Dictionary<string, Sprite>()
        {
            {"Helen", h2}
        };

        var sequence = s;
        interview = new Interview(sequence);

        print(h1);
        print(h2);
        
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
                foreach (var change in seg.spriteChanges)
                {
                    SpriteManager.instance.ChangeSprite(change.Key, change.Value);
                }
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
            StopCueAudio(cueType);
            activeCue= CueType.NONE;
            //Debug.Log(cueType + " Button Up");
        }
    }

    private void SetCueDisplay(CueType cueType)
    {
        if(activeCue != cueType)
        {
            cueDisplay.text = cueType.ToString();
        }
    }

    private void PlayCueAudio(CueType cueType)
    {
        audioManager.Instance.PlayCueAudio(cueType);
    }

    private void StopCueAudio(CueType cueType)
    {
        audioManager.Instance.StopCueAudio(cueType);
    }


    private void Score(InterviewSegment segment)
    {
        if(activeCue== segment.cueType)
        {
            var curveHeight = curve.Evaluate((currentTime - segment.startTime) / segment.durationSeconds);
            GameManager.instance.score += curveHeight * Time.deltaTime;
        }
    }
        
}
