using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    public GameObject prefab;
    public float TimeRespawn;
    private float TimeSpawn;

    public List<GameObject> pipes = new List<GameObject>();

    void Start()
    {
        TimeSpawn = TimeRespawn;
    }

    void Update()
    {
        TimeSpawn -= Time.deltaTime;
        if (TimeSpawn < 0)
        {
            GameObject pipe = Instantiate(prefab);
            pipe.transform.position = new Vector3(transform.position.x, Random.Range(7, -3), 0);
            pipes.Add(pipe);
            TimeSpawn = TimeRespawn;
        }
    }

}
