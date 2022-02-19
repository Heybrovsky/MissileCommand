using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float ScoreValue;
    public TMP_Text ScoreText;
    private string _scoreFromKillingMissiles = "Score: ";
    void Update()
    {
        ScoreText.text = _scoreFromKillingMissiles + ScoreValue;
    }
}
