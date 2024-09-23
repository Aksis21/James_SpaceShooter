using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public List<Transform> asteroidTransform;
    bool newTarget = true;
    Transform targetLoc;
    public float moveSpeed = 1f;
    Vector3 distance;

    private void Update()
    {
        int targetCount = asteroidTransform.Count;
        
        if (newTarget == true)
        {
            int targetNum = Random.Range(0, targetCount);
            targetLoc = asteroidTransform[targetNum];
            newTarget = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetLoc.position, moveSpeed * Time.deltaTime);
        distance = transform.position - targetLoc.position;
        if (distance.magnitude < 1)
        {
            newTarget = true;
        }
    }

}
