using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject backButton;
    public GameObject exitButton;
    public GameObject fadeCanvas;
    public GameObject gameOverMenu;
    public float speed;

    public void MenuButton()
    {
        menuButton.SetActive(false);
        backButton.SetActive(true);
        exitButton.SetActive(true);
        fadeCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void BackButton()
    {
        menuButton.SetActive(true);
        backButton.SetActive(false);
        exitButton.SetActive(false);        
        fadeCanvas.SetActive(false);
        speed = GetComponent<SpeedUpGame>().gameSpeed;
        Time.timeScale = speed;
    }
    public void QuitButton() 
    {
        Application.Quit();
    }
    public void ResetGame()
    {
        menuButton.SetActive(true);
        fadeCanvas.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    public void GameOver()
    {
        menuButton.SetActive(true);
        fadeCanvas.SetActive(true);
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
