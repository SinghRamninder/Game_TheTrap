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
        if (SceneManager.GetActiveScene().name != "GameOver" && SceneManager.GetActiveScene().name != "GameCompleted")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                PausePanel.SetActive(isPaused);
            }


            if (isPaused)
            {
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
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
}
