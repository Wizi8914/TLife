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
    }
    public void NextLevel()
    {
        Scene sc = SceneManager.GetActiveScene();
        sm.LoadScene(sc.buildIndex + 1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
