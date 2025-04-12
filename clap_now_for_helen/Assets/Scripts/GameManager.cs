using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text text;
    float currentTime = 0;

    Interview interview;

    public GameManager()
    {
        //var d1 = new Dialog(
        //    ["hi there", "sam here"]
        //    );
        //interview = new Interview();

    }

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
