using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject mainMenuBarrier;
    public GameObject optionMenu;
    public GameObject optionMenuBarrier;
    public GameObject aboutMenu;
    public GameObject aboutMenuBarrier;

    public void MainMenuStartButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void MainMenuOptionButton()
    {
        MainMenu(false);
        OptionMenu(true);
    }
    public void MainMenuAboutButton()
    {
        MainMenu(false);
        AboutMenu(true);
    }
    public void MainMenuQuitButton()
    {
        Application.Quit();
    }
    public void OptionMenuBack()
    {
        MainMenu(true);
        OptionMenu(false);
    }
    public void AboutMenuBack()
    {
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
