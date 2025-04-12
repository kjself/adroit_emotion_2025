using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{

    public static audioManager Instance;

    public Sound[] responseSound;
    public Sound audienceSound;


    private void Awake()
    {
        Instance = this;
        foreach (Sound s in responseSound)
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

    // Start is called before the first frame update
    private void Start()
    {
        Play("LevelMusic");
    }

    /* This function finds a sound with the same name as the name entered into the function parameter.
     * It then plays the sound (if a sound with the same name is found).
     */
    public void Play(string name)
    {
        //Finding the sound such that the sound's name is equal to the given name
        Sound s = Array.Find<Sound>(responseSound, sound => sound.name == name);
        s.source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
