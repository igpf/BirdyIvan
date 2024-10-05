using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class WallSpawnScript : MonoBehaviour
{
    public GameObject walls;
    public float spawnRate = 2;
    public float timer = 0;
    public float heightOffset = 3;

    void Start()
    {
        CreatePipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            CreatePipe();
            timer = 0;
        }

    }

    void CreatePipe()
    {
        float lowPoint = transform.position.y - heightOffset;
        float hiPoint = transform.position.y + heightOffset;
        Instantiate(walls, new Vector3(transform.position.x, Random.Range(lowPoint, hiPoint), 0), transform.rotation);
    }

    
}
