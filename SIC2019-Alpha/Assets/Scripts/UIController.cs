using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text ScoreText;

    public void UpdateText(int score)
    {
        ScoreText.text = "SCORE: " + score.ToString();
    }
}