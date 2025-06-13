using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class RopeController : MonoBehaviour
{
    public RectTransform ropeTransform;
    public float moveAmount = 10f;
    public float winThreshold = 250f;

    public GameObject winPanel;
    public TMP_Text winText;

    private float originalY;

    void Start()
    {
        originalY = ropeTransform.anchoredPosition.y;
        winPanel.SetActive(false);
    }

    public void MoveRope(bool isPlayer)
    {

       
            if (ropeTransform == null)
            {
                Debug.LogError("RopeTransform is not assigned!");
                return;
            }

            if (winText == null || winPanel == null)
            {
                Debug.LogError("Win UI references not assigned!");
                return;
            }


        if (winPanel.activeSelf) return;

        Vector2 pos = ropeTransform.anchoredPosition;
        pos.y += isPlayer ? moveAmount : -moveAmount;
        ropeTransform.anchoredPosition = pos;

        CheckWinCondition(pos.y);
    }

    void CheckWinCondition(float yPos)
    {
        if (yPos >= originalY + winThreshold)
        {
            ShowWinner("Player Wins!");
        }
        else if (yPos <= originalY - winThreshold)
        {
            ShowWinner("Opponent Wins!");
        }
    }
    void ShowWinner(string result)
    {
        winText.text = result;
        winPanel.SetActive(true);

        // Save stats
        int gamesPlayed = PlayerPrefs.GetInt("GamesPlayed", 0);
        PlayerPrefs.SetInt("GamesPlayed", gamesPlayed + 1);

        if (result == "Player Wins!")
        {
            int gamesWon = PlayerPrefs.GetInt("GamesWon", 0);
            PlayerPrefs.SetInt("GamesWon", gamesWon + 1);
        }

        PlayerPrefs.Save();
    }
    public void ResetGame()
    {
        ropeTransform.anchoredPosition = new Vector2(ropeTransform.anchoredPosition.x, originalY);
        winPanel.SetActive(false);
    }
    public void returnToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}