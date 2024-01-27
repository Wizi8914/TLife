using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TimerScript : MonoBehaviour
{
    [Tooltip("Enter Time Limit in seconds")]
    public float TimeLevelTuto;
    [Tooltip("Enter Time Limit in seconds")]
    public float TimeLevel1;
    [Tooltip("Enter Time Limit in seconds")]
    public float TimeLevel2;
    [Tooltip("Enter Time Limit in seconds")]
    public float TimeLevel3;

    public GameObject TimerPrefab;
    private GameObject PfTmp;

    private float timeLeft;
    private bool timerIsRunning = false;
    private GameObject goCanva;
    private Canvas canva;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeLeft >= 1f)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeLeft = 0;
                timerIsRunning = false;
            }
        }
    }

    public void ChangeScene(int scIndex)
    {
        goCanva = GameObject.Find("Canvas");
        Debug.Log(goCanva.name);
        if (goCanva != null)
        {
            canva = goCanva.GetComponent<Canvas>();
        }

        switch (scIndex)
        {
            case 1:
                timeLeft = TimeLevelTuto;
                PfTmp = Instantiate(TimerPrefab, canva.transform);
                timerIsRunning = true;
                break;
            case 2:
                timeLeft = TimeLevel1;
                PfTmp = Instantiate(TimerPrefab, canva.transform);
                timerIsRunning = true;
                break;
            case 3:
                timeLeft = TimeLevel2;
                PfTmp = Instantiate(TimerPrefab, canva.transform);
                timerIsRunning = true;
                break;
            case 4:
                timeLeft = TimeLevel3;
                PfTmp = Instantiate(TimerPrefab, canva.transform);
                timerIsRunning = true;
                break;
            default:
                break;
        }
    }

    private void updateTimer(float currentTime)
    {
        currentTime -= 1;

        float minutes = Mathf.RoundToInt(currentTime / 60);
        float seconds = Mathf.RoundToInt(currentTime % 60);

        PfTmp.GetComponent<TMP_Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}