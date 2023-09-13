using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCar : MonoBehaviour
{
    public GameObject PrefabCar1;

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
            SpawnCar1();
            nextTime = Time.time + spawnRate;
        }
    }

    void SpawnCar1()
    {
        float addXPos = Random.Range(-road.roadWidth, road.roadWidth);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, 0);
        Instantiate(PrefabCar1, spawnPos, Quaternion.identity);
    }
}
