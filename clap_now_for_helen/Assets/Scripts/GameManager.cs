using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(InterviewManager))]
public class GameManager : MonoBehaviour
{
    public InterviewManager interviewManager;

    private void Start()
    {
        interviewManager = GetComponent<InterviewManager>();
    }
}
