using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    private bool isGameOver = false;

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Time.timeScale = 0f; // pausa el juego
            gameOverPanel.SetActive(true);
            Debug.Log("GAME OVER");
        }
    }

    // Botón de reintentar
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Botón de salir al menú
    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // cambia por el nombre de tu escena de menú
    }
}
