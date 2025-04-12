using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(InterviewManager))]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;//this is a singleton

    public InterviewManager interviewManager;

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
