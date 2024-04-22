using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the game over UI panel
    public TMPro.TextMeshProUGUI gameOverMessage; // Reference to the text component displaying the game over message
    public GameObject restartButton;
    private bool isGameOver = false; // Flag to track the game over state

    void Update()
    {
        // Check if the game over condition is met
        if (!isGameOver)
        {
            // Your game logic here (e.g., arrow shooting, apple spawning, etc.)
        }
    }

    // Method to handle game over
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // Freeze the game
        ShowGameOverPanel("Game Over! You were hit by an Apple!");
    }


    // Method to display the game over panel and message
    private void ShowGameOverPanel(string message)
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            if (gameOverMessage != null)
            {
                gameOverMessage.text = message;
            }
        }
    }
    private void ShowRestartButton()
    {
        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}