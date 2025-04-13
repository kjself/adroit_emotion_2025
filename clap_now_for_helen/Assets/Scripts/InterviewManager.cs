using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterviewManager : MonoBehaviour
{
    public static InterviewManager instance { get; private set;}
    public Interview interview;
    float currentTime = 0;
    int nextSegmentIndex = 0;
    CueType activeCue = CueType.NONE;
    public TMP_Text cueDisplay;
    float interviewTime;
    private ShowCard cardDisplay;
    

    public AnimationCurve curve;

    //[SerializeField]
    //private Sprite h1;
    //[SerializeField]
    //private Sprite h2;
    //public Sprite g1;
    //public Sprite g2;

 

    public InterviewManager()
    {

    }


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {

        //s[0].spriteChanges = new Dictionary<string, Sprite>()
        //{
        //    {"Helen", h1},
        //    {"Guest",  g1}
        //};

        //s[1].spriteChanges = new Dictionary<string, Sprite>()
        //{
        //    {"Helen", h2},
        //    {"Guest",  g2}

        //};
        //s[2].spriteChanges = new Dictionary<string, Sprite>()
        //{
        //    {"Helen", h1}
        //};
        //s[3].spriteChanges = new Dictionary<string, Sprite>()
        //{
        //    {"Helen", h2}
        //};



        //total expected time of a given interview
        Invoke("CalcInterviewTime", 5);

        //print(h1);
        //print(h2);
        
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        //print(nextSegmentIndex);
        for (int i = nextSegmentIndex; i < interview.sequence.Length; i++)
        {
        
            var seg = interview.sequence[i];
            if (seg.startTime <= currentTime && !seg.dialog.isPlaying)
            {
                seg.dialog.Play();
                //foreach (var change in seg.spriteChanges)
                //{
                //    SpriteManager.instance.ChangeSprite(change.Key, change.Value);
                //}
                nextSegmentIndex = i+1;
                
            }
            else
            {
                break;
            }
        }

        if (currentTime >= interviewTime)
        {
            if(cardDisplay != null)
            cardDisplay.CardShow();
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

    private void CalcInterviewTime()
    {
        interviewTime = interview.sequence[interview.sequence.Length - 1].startTime + interview.sequence[interview.sequence.Length - 1].durationSeconds;

    }


}
