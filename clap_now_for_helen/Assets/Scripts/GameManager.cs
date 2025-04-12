using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text text;
    float currentTime = 0;

    float targetStart = 2;
    float targetEnd = 5;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        text.text = currentTime.ToString();

        if (currentTime >= targetStart && currentTime < targetEnd && Input.GetKeyDown(KeyCode.Return))
        {
            text.color = Color.red;
        }
    }
}
