using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVL3_RandomEvents : MonoBehaviour
{
    public static LVL3_RandomEvents instance { get; private set; }
    private int eventNumber;
    
    void Start()
    {
        instance = this;   
    }

    void Update()
    {
        if (eventNumber == 1)
        {
            int activescene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(activescene);
            eventNumber = 0;
        }
        if (eventNumber == 2)
        {
            HealthManager.Instance.Damage(1f);
            Debug.Log("Damage " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 3)
        {
            HealthManager.Instance.Heal(1f);
            Debug.Log("Heal " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 4)
        {
            LVL3_Time.instance.DecreaseTime(10f);
            Debug.Log("TimeDecrease " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 5)
        {
            LVL3_Time.instance.IncreaseTime(10f);
            Debug.Log("Time Increase " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 6)
        {
            HealthManager.Instance.DecreaseLife(1f);
            Debug.Log("Life Decrease " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 7)
        {
            HealthManager.Instance.IncreaseLife(1f);
            Debug.Log("Life Increase " + eventNumber);
            eventNumber = 0;
        }
        if (eventNumber == 8)
        {
            Debug.Log("Game Over!! " + eventNumber);
            eventNumber = 0;
        }
    }

    public void RandomEvent()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };
        int[] weighs = { 10, 10, 10, 10, 10, 10, 10, 2 };

        int totalweight = 0;
        foreach (int weight in weighs)
        {
            totalweight += weight;
        }

        int randomvalue = Random.Range(1, totalweight);
        int cumulativeWeight = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            cumulativeWeight += weighs[i];
            if (randomvalue <= cumulativeWeight)
            {
                eventNumber = i; 
                break;
            }
        }
    }
}
