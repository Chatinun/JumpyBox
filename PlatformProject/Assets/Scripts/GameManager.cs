using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float timer;

    [HideInInspector] public bool isGameEnded;

    [HideInInspector] public float key;
    public float maxKey;

    [SerializeField] private GameObject pausePanel;
    private bool isGamePaused;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI keyText;
    [SerializeField] private float restartDelay = 1f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timerText.text = timer.ToString("F2");
        keyText.text = key + " / " + maxKey;
    }
    void Update()
    {
        if (!isGameEnded)
        {
            TimerUI();
            keyText.text = key + " / " + maxKey;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                pausePanel.SetActive(true);
                isGamePaused = true;
                Time.timeScale = 0;
            }
            else
            {
                pausePanel.SetActive(false);
                isGamePaused = false;
                Time.timeScale = 1;
            }
            
        }

    }

    public void Resume()
    {
        if (!isGamePaused)
        {
            pausePanel.SetActive(true);
            isGamePaused = true;
            Time.timeScale = 0;
        }
        else
        {
            pausePanel.SetActive(false);
            isGamePaused = false;
            Time.timeScale = 1;
        }
    }

    public void BackToMenu()
    {
        LevelLoader.instance.LoadMainMenu();
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void BackToMenuEnding()
    {
        PlayerPrefs.DeleteKey("SavedLevel");
        LevelLoader.instance.LoadMainMenu();
        Time.timeScale = 1;
        isGamePaused = false;
    }

    void TimerUI()
    {
        timer += Time.deltaTime;
        int intTime = (int)timer;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = timer * 100;
        fraction = (fraction % 100);

        timerText.text = System.String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }

    public void RestartScene()
    {
        Invoke("RestartSceneDelay", restartDelay);
    }

    void RestartSceneDelay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameEnded()
    {
        isGameEnded = true;
        PlayerController.instance.rb.velocity = Vector2.zero;
        CameraController.instance.zoomActive = true;
        Invoke("LevelLoaderDelay", 2f);
    }

    void LevelLoaderDelay()
    {
        LevelLoader.instance.LoadNextLevel();
    }

    public void ApplicationExit()
    {
        Application.Quit();
    }

    public void TimerAddToTotal()
    {
        PlayerPrefs.SetFloat("TotalTimer", PlayerPrefs.GetFloat("TotalTimer") + timer);
        Debug.Log(PlayerPrefs.GetFloat("TotalTimer"));
    }

}
