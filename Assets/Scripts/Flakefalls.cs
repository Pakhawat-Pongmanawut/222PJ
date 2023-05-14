using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flakefalls : MonoBehaviour
{
    public GameObject flakeShapePrefab;

    void Start()
    {
        InvokeRepeating("SpawnflakeShape", 0f, 0.5f);
    }
     
    void SpawnflakeShape() 
    {
        float xPos = Random.Range(-10f, 10f);
        Vector3 spawnPos = new Vector3(xPos, 7f, 0f);

        GameObject snowflake = Instantiate(flakeShapePrefab, spawnPos, Quaternion.identity);
        snowflake.transform.parent = transform;
    }
}
