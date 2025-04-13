using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(InterviewManager))]
[RequireComponent(typeof(InputHandler))]

public class GameManager : MonoBehaviour
{
    public static GameManager instance;//this is a singleton

    public InterviewManager interviewManager;
    public float score;

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
        interviewManager = GetComponent<InterviewManager>();
    }

}
