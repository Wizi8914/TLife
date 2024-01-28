using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelObject : MonoBehaviour
{
    private ScenesManager sm;
    public GameObject endLevelCanva;

    public Sprite victorySprite;

    private void Start()
    {
        // Wait 1 second before showing the end level canvas
        StartCoroutine(ShowEndLevelCanvas());
        sm = FindObjectOfType<ScenesManager>();
    }

    public void NextLevel()
    {
        Scene sc = SceneManager.GetActiveScene();
        sm.LoadScene(sc.buildIndex + 1);
    }

    private IEnumerator ShowEndLevelCanvas()
    {
        yield return new WaitForSeconds(1f);

        endLevelCanva.GetComponent<Canvas>().GetComponentsInChildren<Image>()[2].sprite = victorySprite;

        Instantiate(endLevelCanva);
    }
}
