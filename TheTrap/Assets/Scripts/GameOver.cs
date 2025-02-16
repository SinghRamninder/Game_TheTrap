using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip audiosource;


    private void Start()
    {
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        musicSource.clip = audiosource;
        //musicSource.time = 1.6f;
        musicSource.Play();
    }

    public void restart()
    {
        SceneChange.Instance.Restart();
    }

    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
