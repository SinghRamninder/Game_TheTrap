using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance {  get; private set; }

    private float currenthealth = 3;
    private float currentlives = 3;
    public TMP_Text lives;
    public GameObject canvas;
    public Image heartimage;
    public Sprite[] heartsprites;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (currenthealth > 0)
        {
            heartimage.sprite = heartsprites[Convert.ToInt32(currenthealth * 2)];
            lives.text = "x" + currentlives.ToString();
        }
        else if (currentlives >0)
        {
            currentlives -= 1f;
            currenthealth = 3f;
            int activescene = SceneManager.GetActiveScene().buildIndex;
            Physics2D.IgnoreLayerCollision(7, 8, false);
            SceneManager.LoadScene(activescene);
        }

        if (currentlives == 0)
        {
            Debug.Log("GameOver....");
        }
    }

    public void Damage(float damage)
    {
        currenthealth -= damage;
    }
    public void Heal(float heal)
    {
        currenthealth += heal;
    }
    public void DecreaseLife(float decrease)
    {
        currentlives -= decrease;
    }
    public void IncreaseLife(float increase)
    {
        currentlives += increase;
    }
}
