using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    public GameObject ItemReverse;

    private float nextTime = 0.0f;
    public float spawnRate = 1.0f;
    public Road road;
    // Start is called before the first frame update
    void Start()
    {
        road = GameObject.Find("Road").GetComponent<Road>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextTime< Time.time)
        {
            SpawnReverse();
            nextTime = Time.time + spawnRate;
        }
    }

    void SpawnReverse()
    {
        float addXPos = Random.Range(-road.roadWidth-4, road.roadWidth-4);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, 0);
        Instantiate(ItemReverse, spawnPos, Quaternion.Euler(0, 180, 0));
    }
}
