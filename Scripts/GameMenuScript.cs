using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject backButton;
    public GameObject optionButton;
    public GameObject exitButton;

    public void MenuButton()
    {
        Time.timeScale = 0;
        menuButton.SetActive(false);
        backButton.SetActive(true);
        optionButton.SetActive(true);
        exitButton.SetActive(true);
    }
    public void BackButton()
    {
        Time.timeScale = 1;
        backButton.SetActive(false);
        optionButton.SetActive(false);
        exitButton.SetActive(false);
        menuButton.SetActive(true);
    }
    public void OptionButton()
    {
        backButton.SetActive(false);
        optionButton.SetActive(false);
        exitButton.SetActive(false);
        // enable other buttons here
    }
    public void QuitButton() 
    {
        Application.Quit();
    }
}
