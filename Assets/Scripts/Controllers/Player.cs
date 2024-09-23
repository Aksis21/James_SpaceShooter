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
    }

    void PlayerMovement(Vector3 offset)
    {
        transform.position += offset * Time.deltaTime;
    }
}
