using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCar : MonoBehaviour
{
    public GameObject PrefabCar1;
    public GameObject PrefabSpace;
    public GameObject PrefabOldCar;

    private float nextTime = 0.0f;
    public float spawnRate = 0.3f;

    public Road road;
    // Start is called before the first frame update
    void Start()
    {
        road = GameObject.Find("Road").GetComponent<Road>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nextTime < Time.time)
        {
            SpawnEnemy();
            nextTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        float addXPos = Random.Range(-road.roadWidth-4, road.roadWidth-4);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, 0);
        int rand = (int)Random.Range(0, 3);
        if (rand == 0)
        {
            Instantiate(PrefabCar1, spawnPos, Quaternion.identity);
        }
        else if(rand == 1)
        {
            Instantiate(PrefabSpace, spawnPos + new Vector3(0,-5, -21.5f), Quaternion.identity);
        }
        else
        {
            Instantiate(PrefabOldCar, spawnPos + new Vector3(0, -5, -18f), Quaternion.identity);
        }
    }
}
