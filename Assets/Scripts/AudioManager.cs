using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance {  get; private set; } 

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource Jump;
    [SerializeField] AudioSource LVL3_timecount;

    public AudioClip background;
    public AudioClip lvl3back;
    public AudioClip jump;
    public AudioClip LifeDecrease;
    public AudioClip LVL3_DeathPlate;
    public AudioClip LVL3_Negative;
    public AudioClip LVL3_Positive;
    public AudioClip spikeHit;
    public AudioClip magereg;
    public AudioClip timecountdown;
    public AudioClip timesup;

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
        PlayBackgroundMusic();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        if (SceneManager.GetActiveScene().name == "Level 3")
        {
            if (musicSource.clip != lvl3back)
            {
                musicSource.clip = lvl3back;
                musicSource.time = 0.6f;
                musicSource.Play();
            }
        }
        else
        {
            if (musicSource.clip != background)
            {
                musicSource.clip = background;
                musicSource.time = 1.6f;
                musicSource.Play();
            }
        }
    }

    public void sfxplay(AudioClip clip, float vol)
    {
        SFXSource.PlayOneShot(clip, Mathf.Clamp(vol, 0f, 1f));
    }

    public void jumpsound(float vol)
    {
        Jump.clip = jump;
        Jump.volume = Mathf.Clamp(vol, 0, 1);
        Jump.Play();
    }

    public void lvl3timecount()
    {
        LVL3_timecount.clip = timecountdown;
        LVL3_timecount.Play();
    }

    public void lvl3timecountstop()
    {
        LVL3_timecount.Stop();
    }

    public void pausemusic()
    {
        musicSource.Pause();
    }

    public void unpausemusic()
    {
        musicSource.UnPause();
    }

    public void stopmusic()
    {
        musicSource.Stop();
    }

    public void restartmusic()
    {
        musicSource.Play();
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
