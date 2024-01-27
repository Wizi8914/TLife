using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;

    public TimerScript timerScript;

    private int currentSceneID;

    private void Start()
    {

    }

    private void OnLevelWasLoaded(int currentSceneID)
    {
        timerScript.ChangeScene(currentSceneID);
    }

    public void LoadScene(int sceneID)
    {
        currentSceneID = sceneID;
        SceneManager.LoadScene(sceneID);
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
    public void QuitGame()
    {
        Application.Quit();
    }
}
