using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float orbitSpeed = 1f;
    public float orbitRadius = 1f;
    int orbitIndex = 0;

    void Update()
    {
        OrbitalMotion(orbitRadius, orbitSpeed, planetTransform);
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        float orbitAngle = Mathf.Deg2Rad;

        List<Vector3> orbitPoints = new List<Vector3>();
        for (int i = 0; i < 361; i++)
        {
            Vector3 orbPoint = new Vector3(Mathf.Cos(i * orbitAngle), Mathf.Sin(i * orbitAngle)) * radius;
            orbPoint += target.position;
            orbitPoints.Add(orbPoint);
        }

        transform.position = Vector3.MoveTowards(transform.position, orbitPoints[orbitIndex], speed * Time.deltaTime);

        if(transform.position == orbitPoints[orbitIndex])
        {
            if (orbitIndex == 360)
                orbitIndex = 0;
            else
                orbitIndex++;
        }
    }
}
