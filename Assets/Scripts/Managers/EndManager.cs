using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    private ScenesManager sm;

    private void Start()
    {
        sm = FindObjectOfType<ScenesManager>();
    }

    public void RefreshLevel()
    {
        Scene sc = SceneManager.GetActiveScene();
        sm.LoadScene(sc.buildIndex);
        Time.timeScale = 1;
    }
    public void NextLevel()
    {
        Scene sc = SceneManager.GetActiveScene();
        sm.LoadScene(sc.buildIndex + 1);
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void LoadEndMenu()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
