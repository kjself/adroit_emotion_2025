using UnityEngine.Audio;
using UnityEngine;
public class Dialog 
{
    public string subtitle;
    public AudioClip voiceOver;
    public bool isPlaying = false;

    public Dialog(string subtitle)
    {
        this.subtitle = subtitle;
    }

    public void Play()
    {
        SubtitleManager.instance.ChangeSubtitle(subtitle);
        isPlaying = true;
    }
}
