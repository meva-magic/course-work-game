using UnityEngine;
using TMPro;

public class ScoreDisplayHandler : MonoBehaviour
{
    public TMP_Text mainScore;
    public TMP_Text deathScore;

    void Start()
    {
        UpdateScore(Sword.instance.Score);
    }

    public void UpdateScore(int newScore)
    {
        mainScore.text = "<Score: " + newScore.ToString() + ">";
        deathScore.text = newScore.ToString();
    }
}
