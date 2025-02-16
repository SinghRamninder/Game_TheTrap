using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class LVL3_Time : MonoBehaviour
{
    public static LVL3_Time instance {  get; private set; }

    public float totaltime;
    public float timeremaining;
    public TMP_Text time;
    public Animator levelfailed;
    public GameObject lvlfailedcanvas;
    public GameObject canvas2;
    private bool timesup = true;
    public bool timepause = false;
    private bool countdownstart = false;
    private float savedhealth;
    private float savedlife;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(lvlfailedcanvas);
            DontDestroyOnLoad(canvas2);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        time = GameObject.Find("Countdown")?.GetComponent<TMP_Text>();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        timeremaining = totaltime;
        savedhealth = HealthManager.Instance.savehealth();
        savedlife = HealthManager.Instance.savelife();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Level 3")
        {
            Destroy(gameObject);
            Destroy(canvas2);
            Destroy(lvlfailedcanvas);
        }

        if (!timepause)
        {
            if (timeremaining >= 0)
            {
                timeremaining -= Time.deltaTime;
                DisplayTime(timeremaining);
            }
            else if (timesup)
            {
                lvlfailedcanvas.SetActive(true);
                PauseMenu.Instance.lvlfailedtrue();
                AudioManager.Instance.lvl3timecountstop();
                StartCoroutine(lvlfailed());
                timesup = false;
            }

            if (timeremaining <= 10 && !countdownstart)
            {
                AudioManager.Instance.lvl3timecount();
                countdownstart = true;
            }
        }
    }

    private void DisplayTime(float displaytime)
    {
        displaytime += 1;

        float minutes = Mathf.FloorToInt(displaytime / 60);
        float seconds = Mathf.FloorToInt(displaytime % 60);

        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void DecreaseTime(float time)
    {
        timeremaining -= time;
    }
    public void IncreaseTime(float time)
    {
        timeremaining += time;
    }

    public void timepausetrue()
    {
        timepause = true;
    }

    public void timepausefalse()
    {
        timepause = false;
    }

    IEnumerator lvlfailed()
    {
        levelfailed.SetTrigger("Start");
        AudioManager.Instance.sfxplay(AudioManager.Instance.timesup, 1f);
        AudioManager.Instance.stopmusic();
        yield return new WaitForSeconds(0.85f);
        Time.timeScale = 0f;
    }

    public void tryagain()
    {
        HealthManager.Instance.sethealth(savedhealth);
        HealthManager.Instance.sethealth(savedlife);
        Time.timeScale = 1f;
        timeremaining = totaltime + 1;
        lvlfailedcanvas.SetActive(false);
        AudioManager.Instance.restartmusic();
        timesup =true;
        countdownstart = false;
    }

}
