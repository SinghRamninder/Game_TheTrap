using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange Instance { get; private set; }

    [SerializeField] Animator scenetransition;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Scenechange()
    {
        StartCoroutine(Nextscene());
    }

    public void Restart()
    {
        StartCoroutine(ResetGame());
    }
    
    public void Over()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator Nextscene()
    {
        scenetransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        scenetransition.SetTrigger("Start");
    }

    IEnumerator ResetGame()
    {
        HealthManager.Instance.restartgame();
        scenetransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level 1");
        scenetransition.SetTrigger("Start");
    }

    IEnumerator GameOver()
    {
        scenetransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
        scenetransition.SetTrigger("Start");
    }
}
