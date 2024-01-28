using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelObject : MonoBehaviour
{
    private ScenesManager sm;
    public GameObject endLevelCanva;

    

    private void Start()
    {
        Instantiate(endLevelCanva);
        sm = FindObjectOfType<ScenesManager>();
        Debug.Log(sm);
    }

    public void NextLevel()
    {
        Debug.Log(sm);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        Scene sc = SceneManager.GetActiveScene();
        sm.LoadScene(sc.buildIndex + 1);
    }
}
