using UnityEngine.Audio;
using UnityEngine;
public class Dialog 
{
    public string subtitle;
    //public AudioClip voiceOver;
    public string voiceOverName;
    public bool isPlaying = false;

    public Dialog(string subtitle)
    {
        this.subtitle = subtitle;
    }
    public Dialog(string subtitle, string voiceOverName)
    {
        this.subtitle = subtitle;
        this.voiceOverName = voiceOverName;
    }

    public void Play()
    {
        SubtitleManager.instance.ChangeSubtitle(subtitle);
        if(voiceOverName != "")
        {
           audioManager.Instance.Play(voiceOverName);
        }
        isPlaying = true;
    }
}
