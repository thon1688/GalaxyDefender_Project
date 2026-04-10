using UnityEngine;
using TMPro; // Required for TextMeshPro UI
using UnityEngine.SceneManagement; // Required to reload the level

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;
    public GameObject restartButton;

    private int score = 0;
    public bool isGameOver = false;

    // This gets called when a laser hits an asteroid
    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            scoreText.text = "Score: " + score;
        }
    }

    // This gets called when an asteroid hits the player
    public void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
        restartButton.SetActive(true);

        // Stop enemies from spawning (if your SpawnManager uses an InvokeRepeating)
        Object.FindFirstObjectByType<SpawnManager>().CancelInvoke();
    }

    // We will link this to your UI Button
    public void RestartGame()
    {
        // Reloads the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}