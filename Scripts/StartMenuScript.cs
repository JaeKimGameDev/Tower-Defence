using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public GameObject gameTitle;
    //public TextMeshProUGUI mainTitle;
    public GameObject mainMenu;
    public GameObject mainMenuBarrier;
    public GameObject optionMenu;
    public GameObject optionMenuBarrier;
    public GameObject aboutMenu;
    public GameObject aboutMenuBarrier;

    // main menu -> start game
    public void MainMenuStartButton()
    {
        SceneManager.LoadScene("Level1");
    }
    // main menu -> options
    public void MainMenuOptionButton()
    {
        gameTitle.GetComponent<TextMeshProUGUI>().text = "Audio Menu";
        MainMenu(false);
        OptionMenu(true);
    }
    // main menu -> about menu
    public void MainMenuAboutButton()
    {
        gameTitle.SetActive(false);
        MainMenu(false);
        AboutMenu(true);
    }
    // main menu -> quit game
    public void MainMenuQuitButton()
    {
        Application.Quit();
    }
    // option menu -> main menu
    public void OptionMenuBack()
    {
        gameTitle.GetComponent<TextMeshProUGUI>().text = "Random Defence";
        MainMenu(true);
        OptionMenu(false);        
    }
    // about menu -> main menu
    public void AboutMenuBack()
    {
        gameTitle.SetActive(true);
        MainMenu(true);
        AboutMenu(false);
    }
    public void MainMenu(bool activate)
    {
        mainMenu.SetActive(activate);
        mainMenuBarrier.SetActive(activate);
    }
    public void OptionMenu(bool activate)
    {
        optionMenu.SetActive(activate);
        optionMenuBarrier.SetActive(activate);
    }
    public void AboutMenu(bool activate)
    {
        aboutMenu.SetActive(activate);
        aboutMenuBarrier.SetActive(activate);
    }
}
