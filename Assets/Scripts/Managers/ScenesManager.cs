using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionMenu;
    //private static bool created = false;
    //
    //void Awake()
    //{
    //    if (!created)
    //    {
    //        DontDestroyOnLoad(this.gameObject);
    //        created = true;
    //    }
    //}

    public void LoadScene(int sceneID)
    {
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
