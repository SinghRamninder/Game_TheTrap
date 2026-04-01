using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpSpike : MonoBehaviour
{
    public float speed = 2f; 
    private bool isMoving = false;
    public float Position;
    public GameObject FloorSpike;
    public UnityEngine.Rendering.Universal.Light2D targetLight;

    
    private void OnTriggerEnter2D(Collider2D UpSpikeTrigger)
    {
        if (UpSpikeTrigger.gameObject.CompareTag("Player") && !isMoving)
        {
            Transform FloorSpikePos = FloorSpike.transform;
            isMoving = true;
            StartCoroutine(MoveSpike(new Vector3(FloorSpikePos.position.x, Position, FloorSpikePos.position.z)));
            targetLight.enabled = true;
        }
    }

    private IEnumerator MoveSpike(Vector3 targetPosition)
    {
        Transform FloorSpikePos = FloorSpike.transform;

        
        while (Vector3.Distance(FloorSpikePos.position, targetPosition) > 0.01f)
        {
            FloorSpikePos.position = Vector3.Lerp(FloorSpikePos.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }


        FloorSpikePos.position = targetPosition;

        isMoving = false;
    }
}
