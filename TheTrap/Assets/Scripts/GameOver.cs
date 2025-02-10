using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
