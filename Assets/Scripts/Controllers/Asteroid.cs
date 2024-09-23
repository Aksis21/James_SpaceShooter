using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    Vector3 destination = Vector3.zero;
    Vector3 distance;
    bool newDestination = true;

    void Update()
    {
        if (newDestination)
        {
            destination.x = transform.position.x + Random.Range(-maxFloatDistance, maxFloatDistance);
            destination.y = transform.position.y + Random.Range(-maxFloatDistance, maxFloatDistance);
            newDestination = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed);

        distance = transform.position - destination;
        if (distance.magnitude < arrivalDistance)
            newDestination = true;
    }
}
