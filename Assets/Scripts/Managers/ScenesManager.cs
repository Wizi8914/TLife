using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject creditMenu;

    public TimerScript timerScript;

    private void Start()
    {

    }

    private void OnLevelWasLoaded(int currentSceneID)
    {
        timerScript.ChangeScene(currentSceneID);
    }

    public void LoadScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        Time.timeScale = 1;
    }
    public void MainMenu(bool isActive)
    {
        if(mainMenu != null)
        {
            mainMenu.SetActive(isActive);
        }
    }
    public void OptionMenu(bool isActive)
    {
        if(optionMenu != null)
        {
            optionMenu.SetActive(isActive);
        }
    }
    public void CreditMenu(bool isActive)
    {
        if(creditMenu != null)
        {
            creditMenu.SetActive(isActive);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
