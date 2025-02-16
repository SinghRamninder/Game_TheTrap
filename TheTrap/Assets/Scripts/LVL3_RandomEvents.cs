using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;

public class LVL3_RandomEvents : MonoBehaviour
{
    public static LVL3_RandomEvents instance { get; private set; }

    public GameObject player;
    private int eventNumber;
    public Animator eventsanimation;
    public GameObject healthplus;
    public GameObject healthplusicon;
    public GameObject healthminus;
    public GameObject healthminusicon;
    public GameObject timeplus;
    public GameObject timeplusicon;
    public GameObject timeminus;
    public GameObject timeminusicon;
    public GameObject lifeplus;
    public GameObject lifeplusicon;
    public GameObject lifeminus;
    public GameObject lifeminusicon;

    public GameObject Mazeregenerate;
    public TMP_Text regeneratetext;

    public GameObject instdeath;
    public TMP_Text deathtxt;
    
    void Start()
    {
        instance = this;
        Time.timeScale = 0f;
        Time.timeScale = 1f;
    }

    void Update()
    {
        LVL3_PlayerMovement playermove = player.GetComponent<LVL3_PlayerMovement>();

        if (eventNumber == 3 || eventNumber == 5 || eventNumber == 7)
        {
            AudioManager.Instance.sfxplay(AudioManager.Instance.LVL3_Positive, 0.35f);
        }
        if (eventNumber == 2 || eventNumber == 4 || eventNumber == 6)
        {
            AudioManager.Instance.sfxplay(AudioManager.Instance.LVL3_Negative, 0.65f);
        }
        if (eventNumber == 8)
        {
            AudioManager.Instance.stopmusic();
            AudioManager.Instance.sfxplay(AudioManager.Instance.LVL3_DeathPlate, 0.7f);
        }

        if (eventNumber == 1)
        {
            AudioManager.Instance.sfxplay(AudioManager.Instance.magereg, 1f);
        }

        if (eventNumber == 1)
        {
            LVL3_Time.instance.timepausetrue();
            playermove.platetrigger = true;
            Mazeregenerate.SetActive(true);
            StartCoroutine(mazereg());
            eventNumber = 0;
        }
        if (eventNumber == 2)
        {
            healthminus.SetActive(true);
            healthminusicon.SetActive(true);
            healthplus.SetActive(false);
            healthplusicon.SetActive(false);
            timeplus.SetActive(false);
            timeplusicon.SetActive(false);
            timeminus.SetActive(false);
            timeminusicon.SetActive(false);
            lifeplus.SetActive(false);
            lifeplusicon.SetActive(false);
            lifeminus.SetActive(false);
            lifeminusicon.SetActive(false);
            LVL3_Time.instance.timepausetrue();
            playermove.platetrigger = true;
            StartCoroutine(damage());
            Debug.Log("Damage " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 3)
        {
            healthminus.SetActive(false);
            healthminusicon.SetActive(false);
            healthplus.SetActive(true);
            healthplusicon.SetActive(true);
            timeplus.SetActive(false);
            timeplusicon.SetActive(false);
            timeminus.SetActive(false);
            timeminusicon.SetActive(false);
            lifeplus.SetActive(false);
            lifeplusicon.SetActive(false);
            lifeminus.SetActive(false);
            lifeminusicon.SetActive(false);
            LVL3_Time.instance.timepausetrue();
            playermove.platetrigger = true;
            StartCoroutine(heal());
            Debug.Log("Heal " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 4)
        {
            healthminus.SetActive(false);
            healthminusicon.SetActive(false);
            healthplus.SetActive(false);
            healthplusicon.SetActive(false);
            timeplus.SetActive(false);
            timeplusicon.SetActive(false);
            timeminus.SetActive(true);
            timeminusicon.SetActive(true);
            lifeplus.SetActive(false);
            lifeplusicon.SetActive(false);
            lifeminus.SetActive(false);
            lifeminusicon.SetActive(false);
            LVL3_Time.instance.timepausetrue();
            playermove.platetrigger = true;
            StartCoroutine(decreasetime());
            LVL3_Time.instance.DecreaseTime(10f);
            Debug.Log("TimeDecrease " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 5)
        {
            healthminus.SetActive(false);
            healthminusicon.SetActive(false);
            healthplus.SetActive(false);
            healthplusicon.SetActive(false);
            timeplus.SetActive(true);
            timeplusicon.SetActive(true);
            timeminus.SetActive(false);
            timeminusicon.SetActive(false);
            lifeplus.SetActive(false);
            lifeplusicon.SetActive(false);
            lifeminus.SetActive(false);
            lifeminusicon.SetActive(false);
            LVL3_Time.instance.timepausetrue();
            playermove.platetrigger = true;
            StartCoroutine(increasetime());
            LVL3_Time.instance.IncreaseTime(5f);
            Debug.Log("Time Increase " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 6)
        {
            healthminus.SetActive(false);
            healthminusicon.SetActive(false);
            healthplus.SetActive(false);
            healthplusicon.SetActive(false);
            timeplus.SetActive(false);
            timeplusicon.SetActive(false);
            timeminus.SetActive(false);
            timeminusicon.SetActive(false);
            lifeplus.SetActive(false);
            lifeplusicon.SetActive(false);
            lifeminus.SetActive(true);
            lifeminusicon.SetActive(true);
            LVL3_Time.instance.timepausetrue();
            playermove.platetrigger = true;
            StartCoroutine(decraselife());
            Debug.Log("Life Decrease " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 7)
        {
            healthminus.SetActive(false);
            healthminusicon.SetActive(false);
            healthplus.SetActive(false);
            healthplusicon.SetActive(false);
            timeplus.SetActive(false);
            timeplusicon.SetActive(false);
            timeminus.SetActive(false);
            timeminusicon.SetActive(false);
            lifeplus.SetActive(true);
            lifeplusicon.SetActive(true);
            lifeminus.SetActive(false);
            lifeminusicon.SetActive(false);
            LVL3_Time.instance.timepausetrue();
            playermove.platetrigger = true;
            StartCoroutine(increaselife());
            Debug.Log("Life Increase " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 8)
        {
            instdeath.SetActive(true);
            LVL3_Time.instance.timepausetrue();
            playermove.platetrigger = true;
            StartCoroutine(instantdeath());
            Debug.Log("Game Over!! " + eventNumber);
            eventNumber = 0;
        }
    }

    public void RandomEvent()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };
        int[] weighs = { 8, 10, 6, 10, 6, 10, 6, 2 };

        int totalweight = 0;
        foreach (int weight in weighs)
        {
            totalweight += weight;
        }

        int randomvalue = Random.Range(1, totalweight + 1);
        int cumulativeWeight = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            cumulativeWeight += weighs[i];
            if (randomvalue <= cumulativeWeight)
            {
                if (i == 2)
                {
                    bool checkhp = HealthManager.Instance.hpfull();
                    if (!checkhp)
                    {
                        eventNumber = numbers[i];
                        break;
                    }
                    else
                    {
                        RandomEvent();
                        break;
                    }
                }
                else if (i == 6)
                {
                    bool checklife = HealthManager.Instance.lifefull();
                    if (!checklife)
                    {
                        eventNumber = numbers[i];
                        break;
                    }
                    else
                    {
                        RandomEvent();
                        break;
                    }
                }
                else
                {
                    eventNumber = numbers[i];
                    Debug.Log(eventNumber);
                    break;
                }
            }
        }
    }

    IEnumerator damage()
    {
        eventsanimation.SetTrigger("Health-Start");
        yield return new WaitForSeconds(2f);
        eventsanimation.SetTrigger("Health-End");
        LVL3_PlayerMovement playermove = player.GetComponent<LVL3_PlayerMovement>();
        playermove.platetrigger = false;
        LVL3_Time.instance.timepausefalse();
        HealthManager.Instance.Damage(1.5f);
        yield return new WaitForSeconds(0.83f);
        healthminus.SetActive(false);
        healthminusicon.SetActive(false);
    }
    IEnumerator heal()
    {
        eventsanimation.SetTrigger("Health+Start");
        yield return new WaitForSeconds(2f);
        eventsanimation.SetTrigger("Health+End");
        LVL3_PlayerMovement playermove = player.GetComponent<LVL3_PlayerMovement>();
        playermove.platetrigger = false;
        LVL3_Time.instance.timepausefalse();
        HealthManager.Instance.Heal(1f);
        yield return new WaitForSeconds(0.83f);
        healthplus.SetActive(false);
        healthplusicon.SetActive(false);
    }
    IEnumerator decreasetime()
    {
        eventsanimation.SetTrigger("Time-Start");
        yield return new WaitForSeconds(2f);
        eventsanimation.SetTrigger("Time-End");
        LVL3_PlayerMovement playermove = player.GetComponent<LVL3_PlayerMovement>();
        playermove.platetrigger = false;
        LVL3_Time.instance.timepausefalse();
        yield return new WaitForSeconds(0.83f);
        timeminus.SetActive(false);
        timeminusicon.SetActive(false);
    }
    IEnumerator increasetime()
    {
        eventsanimation.SetTrigger("Time+Start");
        yield return new WaitForSeconds(2f);
        eventsanimation.SetTrigger("Time+End");
        LVL3_PlayerMovement playermove = player.GetComponent<LVL3_PlayerMovement>();
        playermove.platetrigger = false;
        LVL3_Time.instance.timepausefalse();
        yield return new WaitForSeconds(0.83f);
        timeplus.SetActive(false);
        timeplusicon.SetActive(false);
    }
    IEnumerator decraselife()
    {
        eventsanimation.SetTrigger("Life-Start");
        yield return new WaitForSeconds(2f);
        eventsanimation.SetTrigger("Life-End");
        LVL3_PlayerMovement playermove = player.GetComponent<LVL3_PlayerMovement>();
        playermove.platetrigger = false;
        LVL3_Time.instance.timepausefalse();
        HealthManager.Instance.DecreaseLife(1f);
        yield return new WaitForSeconds(0.83f);
        lifeminus.SetActive(false);
        lifeminusicon.SetActive(false);
    }
    IEnumerator increaselife()
    {
        eventsanimation.SetTrigger("Life+Start");
        yield return new WaitForSeconds(2f);
        eventsanimation.SetTrigger("Life+End");
        LVL3_PlayerMovement playermove = player.GetComponent<LVL3_PlayerMovement>();
        playermove.platetrigger = false;
        LVL3_Time.instance.timepausefalse();
        HealthManager.Instance.IncreaseLife(1f);
        yield return new WaitForSeconds(0.83f);
        lifeplus.SetActive(false);
        lifeplusicon.SetActive(false);
    }

    IEnumerator mazereg()
    {
        string regtext = "MAZE REGENERATING...";
        regeneratetext.text = "";

        for (int i = 0; i < regtext.Length; i++)
        {
            regeneratetext.text += regtext[i];
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);

        
        Mazeregenerate.SetActive(false);
        HealthManager.Instance.Pushatstart();
        LVL3_PlayerMovement playermove = player.GetComponent<LVL3_PlayerMovement>();
        playermove.platetrigger = false;
        LVL3_Time.instance.timepausefalse();
    }

    IEnumerator instantdeath()
    {
        string deathtext = "Wow! You found the rarest plate… too bad it’s your last discovery.";
        deathtxt.text = "";

        for (int i = 0; i < deathtext.Length; i++)
        {
            deathtxt.text += deathtext[i];
            yield return new WaitForSeconds(0.07f);
        }

        yield return new WaitForSeconds(2f);
        LVL3_PlayerMovement playermove = player.GetComponent<LVL3_PlayerMovement>();
        playermove.platetrigger = false;
        LVL3_Time.instance.timepausefalse();
        instdeath.SetActive(false);
        SceneChange.Instance.Over();
    }
}
