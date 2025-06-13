using UnityEngine;
using TMPro;

public class LobbyStatsUI : MonoBehaviour
{
    public TextMeshProUGUI statsText;

    void Start()
    {
        int gamesPlayed = PlayerPrefs.GetInt("GamesPlayed", 0);
        int gamesWon = PlayerPrefs.GetInt("GamesWon", 0);

        statsText.text = $"Games Played = {gamesPlayed}\nGames Won = {gamesWon}";
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
