using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    public int conditionNumber;
    public int actualNumber = 0;

    private ScenesManager sm;
    public GameObject endLevelCanva;


    public Sprite victorySprite;

    void Start()
    {
        
    }
    
    void Update()
    {
        if(actualNumber >= conditionNumber)
        {
            EndLevelCanvas();
        }
    }

    public void IncrementConditionNumber()
    {
        actualNumber++;
    }

    public void EndLevelCanvas()
    {
        // Wait 1 second before showing the end level canvas
        StartCoroutine(ShowEndLevelCanvas());
        sm = FindObjectOfType<ScenesManager>();
    }
    public void NextLevel()
    {
        Scene sc = SceneManager.GetActiveScene();
        sm.LoadScene(sc.buildIndex + 1);
        Time.timeScale = 1;
    }

    private IEnumerator ShowEndLevelCanvas()
    {
        yield return new WaitForSeconds(1f);

        endLevelCanva.GetComponent<Canvas>().GetComponentsInChildren<Image>()[2].sprite = victorySprite;

        Instantiate(endLevelCanva);
        PauseGame();
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
