using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultsDisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        scoreText.text = "Number of our precious : " + GM.totalScore.ToString();
    }
}