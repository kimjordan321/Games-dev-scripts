using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class spawner : MonoBehaviour
{
    private float timeDelay = 2f;
    private float nextSpawn = 0f;
    public static int fish = 0;
    public static int maxFish = 20;
    private bool fishspawn;
    private Vector3 spawnPosition;
    public static float spawnTime = 1;

    //private Transform Spawner;

    public GameObject[] prefab;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update()
    {

        //print(fish);


    }
    void Spawn()
    {
        if (fish < maxFish)
        {
            spawnPosition.x = Random.Range(-12, 28);
            spawnPosition.y = Random.Range(-7, -37);
            spawnPosition.z = Random.Range(-10, 25);
            Instantiate(prefab[Random.Range(0, prefab.Length)], spawnPosition, Quaternion.identity);
            fish++;
        }
    }

}

