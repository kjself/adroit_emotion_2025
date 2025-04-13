using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCard : MonoBehaviour
{

    public TMP_Text scoreText;
    float score = GameManager.instance.score;
    public CanvasGroup cGroup;

    // Start is called before the first frame update
    private void Start()
    {
        cGroup.alpha = 0;
    }
    public void CardShow()
    {
        cGroup.alpha = 1;
        scoreText.text = score.ToString();
    }
}
