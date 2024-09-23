using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    Vector3 linePosition;
    int i = 0;
    float drawSpeed;

    void Start()
    {
        linePosition = starTransforms[0].position;
        drawSpeed = Vector3.Distance(linePosition, starTransforms[i + 1].position) / drawingTime;
    }

    void Update()
    {

        linePosition = Vector3.MoveTowards(linePosition, starTransforms[i+1].position, drawSpeed * Time.deltaTime);
        Debug.DrawLine(starTransforms[i].position, linePosition, Color.white);
        if (linePosition == starTransforms[i+1].position)
        {
            if (i == starTransforms.Count - 2)
                i = 0;
            else
                i += 1;
            drawSpeed = Vector3.Distance(linePosition, starTransforms[i + 1].position) / drawingTime;
        }
    }
}
