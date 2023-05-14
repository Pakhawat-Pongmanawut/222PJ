using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flakebuilds : MonoBehaviour
{
    public int numIterations = 4;
    public float length = 0.1f;
    public float thickness = 0.05f;
    public Color color = Color.white;
    public float xLeft = -1f;
    public float xRight = 1f;
    public float yUp = -1f;
    public float yDown = -5f;
    public float rotationSpeedXLeft = 30f;
    public float rotationSpeedXRight = 45f;
    public float rotationSpeedZLeft = 15f;
    public float rotationSpeedZRight = 30f;
    private float currentRotation = 0f;

    private LineRenderer lineRenderer;
    private Rigidbody2D rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<LineRenderer>().enabled = true;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(Random.Range(xLeft, xRight), yUp);

        lineRenderer = GetComponent<LineRenderer>();
        Color color = new Color(92f, 226f, 255f, Random.Range(0.25f, 0.75f));
        
        Vector3[] points = GenerateSnowflakePoints(numIterations, length);

        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;

        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
        lineRenderer.startWidth = thickness;
        lineRenderer.endWidth = thickness;
        lineRenderer.material.color = color;

    }

    void Update() 
    {
        if (transform.position.y < yDown) 
        {
            Destroy(gameObject);
        }

        float rotationSpeedX = Random.Range(rotationSpeedXLeft, rotationSpeedXRight);
        float rotationSpeedZ = Random.Range(rotationSpeedZLeft, rotationSpeedZRight);
        currentRotation += rotationSpeedX * Time.deltaTime;
        currentRotation += rotationSpeedZ * Time.deltaTime;
        
        if (currentRotation >= 360f) 
        {
            currentRotation -= 360f;
        }
        lineRenderer.transform.rotation = Quaternion.Euler(currentRotation, 0f, currentRotation);
    }

    private Vector3[] GenerateSnowflakePoints(int iterations, float length) 
    {
        Vector3[] points = new Vector3[6];

        points[0] = new Vector3(0f, 0f, 0f);
        points[1] = new Vector3(length/2, 0f, 0f);
        points[2] = new Vector3(-length/2, 0f, 0f);

        for (int i = 0; i < iterations; i++) {
            int numPoints = points.Length;
            Vector3[] newPoints = new Vector3[numPoints * 4 - 3];
            int index = 0;

            for (int j = 0; j < numPoints - 1; j++) 
            {
                Vector3 p1 = points[j];
                Vector3 p2 = points[j + 1];
                Vector3 delta = (p2 - p1) / 3f;

                Vector3 a = p1 + delta;
                Vector3 c = p2 - delta;
                Vector3 b = a + Quaternion.Euler(0f, 0f, 60f) * delta;

                newPoints[index++] = p1;
                newPoints[index++] = a;
                newPoints[index++] = b;
                newPoints[index++] = c;
            }
            newPoints[index] = points[numPoints - 1];
            points = newPoints;
        }
        return points;
    }
}
