using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelObject : MonoBehaviour
{

    private ScenesManager sm;

    private void Awake()
    {
        sm = FindObjectOfType<ScenesManager>();
    }

    private void Start()
    {
        Scene sc = SceneManager.GetActiveScene();
        sm.LoadScene(sc.buildIndex + 1);
    }
}
