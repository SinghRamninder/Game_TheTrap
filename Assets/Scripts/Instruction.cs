using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    public GameObject instructionCanvas;
    void Start()
    {
        StartCoroutine(instruction());
    }

    IEnumerator instruction()
    {
        yield return new WaitForSeconds(5);
        instructionCanvas.SetActive(false);
    }

    
}
