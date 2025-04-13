using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is our audio manager, for tracking which sounds are played at a given time on a given cue.
/// </summary>
public class audioManager : MonoBehaviour
{

    public static audioManager Instance;

    public List<Sound> sounds;
    public Sound audienceSound;

    //sounds = {cue sounds, dialoge, ...}
    private Dictionary<CueType, Sound> cueSoundDist = new Dictionary<CueType, Sound>();
    public Sound[] cueSounds;

    private void Awake()
    {
        Instance = this;

        
        CueType[] cueTypes = (CueType[])Enum.GetValues(typeof(CueType));
        for (int i = 0; i < cueTypes.Length; i++)
        {
            cueSoundDist.Add(cueTypes[i], cueSounds[i]); //there mustn't be less sounds that CueTypes

            sounds.Add(cueSounds[i]);
        }

        foreach (Sound s in sounds)
        {
            //creates an audio source for every sound listed in the AudioManager inspector
            s.source = gameObject.AddComponent<AudioSource>();
            //finding the clip for each audio source
            s.source.clip = s.clip;

            // connecting the volume and pitch values for easier manipulation in the inspector
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    /* This function finds a sound with the same name as the name entered into the function parameter.
     * It then plays the sound (if a sound with the same name is found).
     */

    public void PlayCueAudio(CueType cueType)
    {
         var cueSound= cueSoundDist[cueType];
        Play(cueSound);
    }
    public void StopCueAudio(CueType cueType)
    {
        var cueSound = cueSoundDist[cueType];
        Stop(cueSound);
    }
    public void Play(string name)
    {
        //Finding the sound such that the sound's name is equal to the given name
        Sound s = sounds.Find(sound => sound.name == name);
        s.source.Play();
    }
    public void Play(Sound sound)
    {
        sound.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = sounds.Find(sound => sound.name == name);
        s.source.Stop();
    }

    public void Stop(Sound sound)
    {       
        sound.source.Stop();
    }
}
