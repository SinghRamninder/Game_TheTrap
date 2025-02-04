using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance {  get; private set; }

    private float currenthealth = 3;
    private float currentlives = 3;
    public SpriteRenderer spriteRenderer;
    public Sprite[] heartsprites;
    public TMP_Text lives;
    public GameObject canvas;

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
            spriteRenderer.sprite = heartsprites[System.Convert.ToInt32(currenthealth * 2)];
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
}
