using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float angularSpeed = 45f;
    public float targetAngle = 130f;

    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.up, Color.green);

        float currentRotation = transform.rotation.eulerAngles.z + 90;

        currentRotation = StandardizeAngle(currentRotation);

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

        Debug.Log(currentRotation);
    }

    public float StandardizeAngle(float inAngle)
    {
        inAngle %= 360;

        if (inAngle > 180)
        {
            inAngle -= 360;
        }

        return inAngle;
    }
}
