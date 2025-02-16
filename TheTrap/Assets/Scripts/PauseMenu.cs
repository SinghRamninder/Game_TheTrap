using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }

    public GameObject PausePanel;
    private bool isPaused = false;
    private bool lvlfailed = false;
    private bool musicpaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "GameOver" && SceneManager.GetActiveScene().name != "GameCompleted" && !lvlfailed)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                PausePanel.SetActive(isPaused);
            }


            if (isPaused)
            {
                if (!musicpaused)
                {
                    AudioManager.Instance.pausemusic();
                    musicpaused = true;
                }
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                if (musicpaused)
                {
                    AudioManager.Instance.unpausemusic();
                    musicpaused = false;
                }
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

    }

    public void resume()
    {
        isPaused = false;
        PausePanel.SetActive(false);
    }
    public void restart()
    {
        isPaused = false;
        PausePanel.SetActive(false);
        SceneChange.Instance.Restart();
    }

    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void lvlfailedtrue()
    {
        lvlfailed = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void lvlfailedfalse()
    {
        lvlfailed = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
