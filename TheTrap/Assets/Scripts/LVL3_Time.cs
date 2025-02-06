using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class LVL3_Time : MonoBehaviour
{
    public static LVL3_Time instance {  get; private set; }

    public float totaltime;
    public float timeremaining;
    public TMP_Text time;
    void Start()
    {
        instance = this;
        timeremaining = totaltime;
    }

    void Update()
    {
        if (timeremaining >= 0)
        {
            timeremaining -= Time.deltaTime;
            DisplayTime(timeremaining);
        }
        else
        {
            Debug.Log("Times Up!!");
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

}
