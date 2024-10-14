using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShip : MonoBehaviour
{
    //Assignment mechanic 2
    public GameObject Player;
    float moveSpeed;
    public float angularSpeed;
    float targetAngle;

    private void Start()
    {
        moveSpeed = Random.Range(1, 10);
    }

    void Update()
    {
        Vector3 distance = transform.position - Player.transform.position;

        if (distance.magnitude > 1)
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);

        Vector3 shipToPlayer = Player.transform.position - transform.position;
        targetAngle = Mathf.Atan2(shipToPlayer.y, shipToPlayer.x) * Mathf.Rad2Deg;

        float currentRotation = transform.rotation.eulerAngles.z + 90;

        currentRotation = StandardizeAngle(currentRotation);
        targetAngle = StandardizeAngle(targetAngle);

        if (targetAngle - currentRotation < 0)
        {
            if (currentRotation > targetAngle)
                transform.Rotate(0, 0, -angularSpeed * Time.deltaTime);
        }
        else
        {
            if (currentRotation < targetAngle)
                transform.Rotate(0, 0, angularSpeed * Time.deltaTime);
        }
    }

    public float StandardizeAngle(float inAngle)
    {
        inAngle %= 360;

        inAngle = (inAngle + 360) % 360;

        if (inAngle > 360)
        {
            inAngle -= 360;
        }

        return inAngle;
    }
}
