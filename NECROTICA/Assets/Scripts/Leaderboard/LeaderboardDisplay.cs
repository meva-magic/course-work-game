using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class LeaderboardDisplay : MonoBehaviour
{
    public TMP_Text[] leaderboardEntries = new TMP_Text[5];
    public Button refreshButton; 

    private void Start()
    {
        GetLeaderboard();

        if (refreshButton != null)
        {
            refreshButton.onClick.AddListener(GetLeaderboard);
        }
        else
        {
            Debug.LogWarning("Refresh button is not assigned in the Inspector.");
        }
    }

    public void GetLeaderboard()
    {
        StartCoroutine(GetLeaderboardRoutine());
    }

    private IEnumerator GetLeaderboardRoutine()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:3009/api/leaderboard"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error fetching leaderboard: " + www.error);
            }
            else
            {
                Debug.Log("Raw JSON response: " + www.downloadHandler.text);
                DisplayLeaderboard(www.downloadHandler.text);
            }
        }
    }

    private void DisplayLeaderboard(string json)
    {
        string wrappedJson = "{\"playerScores\":" + json + "}";

        PlayerScoreArray playerScoreArray = JsonUtility.FromJson<PlayerScoreArray>(wrappedJson);

        for (int i = 0; i < leaderboardEntries.Length; i++)
        {
            leaderboardEntries[i].text = "~";
        }

        for (int i = 0; i < playerScoreArray.playerScores.Length && i < leaderboardEntries.Length; i++)
        {
            leaderboardEntries[i].text = $"{playerScoreArray.playerScores[i].name}: {playerScoreArray.playerScores[i].score}";
        }

        Debug.Log("Leaderboard updated:");
        foreach (var playerScore in playerScoreArray.playerScores)
        {
            Debug.Log($"{playerScore.name}: {playerScore.score}");
        }
    }

    [System.Serializable]
    public class PlayerScore
    {
        public string name;
        public int score;
    }

    [System.Serializable]
    public class PlayerScoreArray
    {
        public PlayerScore[] playerScores;
    }
}
