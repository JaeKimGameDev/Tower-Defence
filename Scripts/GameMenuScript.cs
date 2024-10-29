using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject backButton;
    public GameObject exitButton;
    public GameObject fadeCanvas;
    public GameObject gameOverMenu;
    public GameObject soundMenu;
    public float speed;

    public void MenuButton()
    {
        menuButton.SetActive(false);

        // sound menu here
        soundMenu.SetActive(true);
        backButton.SetActive(true);
        exitButton.SetActive(true);
        fadeCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void BackButton()
    {
        menuButton.SetActive(true);
        soundMenu.SetActive(false);
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
        soundMenu.SetActive(false);
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
