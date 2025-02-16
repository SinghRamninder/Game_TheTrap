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
    private bool gameover = true;
    [SerializeField] Animator deathtransition;

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
        if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "GameCompleted")
        {
            canvas.SetActive(false);
        }
        else
        {
            canvas.SetActive(true);
        }

        if (currenthealth > 3)
        {
            currenthealth = 3;
        }
        if (currentlives > 3)
        {
            currentlives = 3;
        }

        if (currenthealth > 0)
        {
            heartimage.sprite = heartsprites[Convert.ToInt32(currenthealth * 2)];
            lives.text = "x" + currentlives.ToString();
        }
        else if (currentlives >0)
        {
            currentlives -= 1f;
            if (currentlives != 0)
            {
                currenthealth = 3f;
                Physics2D.IgnoreLayerCollision(7, 8, false);
                Pushatstart();
            }
            
        }

        if (currentlives <= 0 && gameover)
        {
            SceneChange.Instance.Over();
            gameover = false;
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

    public void restartgame()
    {
        currentlives = 3;
        currenthealth = 3;
        gameover = true;
    }

    public void Pushatstart()
    {
        StartCoroutine(atStart());
    }

    public bool hpfull()
    {
        if (currenthealth == 3)
        {
            return true;
        }

        return false;
    }

    public bool lifefull()
    {
        if (currentlives == 3)
        {
            return true;
        }

        return false;
    }

    public float savehealth()
    {
        return currenthealth;
    }

    public float savelife()
    {
        return currentlives;
    }

    public void sethealth(float health)
    {
        currenthealth = health;
    }

    public void setlife(float life)
    {
        currentlives = life;
    }

    IEnumerator atStart()
    {
        deathtransition.SetTrigger("End");
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deathtransition.SetTrigger("Start");
    }
}
