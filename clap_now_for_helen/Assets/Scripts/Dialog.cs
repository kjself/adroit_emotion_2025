using UnityEngine.Audio;
using UnityEngine;
public class Dialog 
{
    public string[] subtitles;
    public AudioClip voiceOver;

    public Dialog(string[] _subtitles)
    {
        subtitles = _subtitles;
    }
}
