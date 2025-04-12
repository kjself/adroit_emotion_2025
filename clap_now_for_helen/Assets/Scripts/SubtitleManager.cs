using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitleManager : MonoBehaviour
{
    public static SubtitleManager instance { get; private set;}//this is a singleton
    private TMP_Text subtitleText;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        subtitleText = GetComponent<TMP_Text>();
    }

    public void ChangeSubtitle(string newText)
    {
        subtitleText.text = newText;
    }
}
