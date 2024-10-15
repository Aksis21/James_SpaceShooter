using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHolePull : MonoBehaviour
{
    public GameObject blackHole;

    void Start()
    {
        blackHole = GameObject.Find("BlackHole");
    }

    void Update()
    {
        Vector3 moveSpeed = transform.position - blackHole.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, blackHole.transform.position, 1 / moveSpeed.magnitude * Time.deltaTime);
    }
}
