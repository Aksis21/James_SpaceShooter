using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public float moveSpeed = 10.0f;

    void Update()
    {
        Vector3 offset = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
            offset += Vector3.left * moveSpeed;
        if (Input.GetKey(KeyCode.UpArrow))
            offset += Vector3.up * moveSpeed;
        if (Input.GetKey(KeyCode.DownArrow))
            offset += Vector3.down * moveSpeed;
        if (Input.GetKey(KeyCode.RightArrow))
            offset += Vector3.right * moveSpeed;

        PlayerMovement(offset);
    }

    void PlayerMovement(Vector3 offset)
    {
        transform.position += offset * Time.deltaTime;
    }
}
