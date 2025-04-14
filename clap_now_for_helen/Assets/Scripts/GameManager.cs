using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(InterviewManager))]
[RequireComponent(typeof(InputHandler))]

public class GameManager : MonoBehaviour
{
    public static GameManager instance;//this is a singleton
    //[HideInInspector]
    //public InterviewManager interviewManager;
    [HideInInspector]
    public float score = 1000;

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
        //InterviewManager.instance = GetComponent<InterviewManager>();
    }

}
