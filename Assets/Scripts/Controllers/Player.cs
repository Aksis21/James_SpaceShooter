using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float maxSpeed = 10.0f;
    public float accelerationTime = 1f;
    float moveSpeed = 0f;

    public float radarRadius = 1f;
    public int radiusPoints = 5;
    Color radarColor;

    public GameObject powerupPrefab;
    public float powerupRadius = 1f;
    public int powerupsCount = 5;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            moveSpeed += maxSpeed/accelerationTime * Time.deltaTime;
        }
        else
        {
            moveSpeed = 0f;
        }

        Vector3 offset = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
            offset += Vector3.left * moveSpeed;
        if (Input.GetKey(KeyCode.UpArrow))
            offset += Vector3.up * moveSpeed;
        if (Input.GetKey(KeyCode.DownArrow))
            offset += Vector3.down * moveSpeed;
        if (Input.GetKey(KeyCode.RightArrow))
            offset += Vector3.right * moveSpeed;

        offset = offset.normalized * Mathf.Clamp(offset.magnitude, 0, maxSpeed);

        PlayerMovement(offset);

        EnemyRadar(radarRadius, radiusPoints);

        if (Input.GetKeyDown(KeyCode.P))
            SpawnPowerups(powerupRadius, powerupsCount);
    }

    void PlayerMovement(Vector3 offset)
    {
        transform.position += offset * Time.deltaTime;
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        float radarAngle = 360 / circlePoints * Mathf.Deg2Rad;

        List<Vector3> radarPoints = new List<Vector3>();
        for (int i = 0; i < circlePoints + 1; i++)
        {
            Vector3 radPoint = new Vector3(Mathf.Cos(i * radarAngle), Mathf.Sin(i * radarAngle)) * radius;
            radPoint += transform.position;
            radarPoints.Add(radPoint);
        }

        Vector3 enemyDistance = transform.position - enemyTransform.position;

        if (enemyDistance.magnitude < radius)
            radarColor = Color.red;
        else
            radarColor = Color.green;

        for (int i = 0; i < radarPoints.Count - 1; i++)
            Debug.DrawLine(radarPoints[i], radarPoints[i+1], radarColor);
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        float powerupAngle = 360 / numberOfPowerups * Mathf.Deg2Rad;

        List<Vector3> powerupPoints = new List<Vector3>();
        for (int i = 0; i < numberOfPowerups; i++)
        {
            Vector3 powerPoint = new Vector3(Mathf.Cos(i * powerupAngle), Mathf.Sin(i * powerupAngle)) * radius;
            powerPoint += transform.position;
            powerupPoints.Add(powerPoint);
        }

        for (int i = 0; i < numberOfPowerups; i++)
            Instantiate(powerupPrefab, powerupPoints[i], Quaternion.identity);
    }
}
