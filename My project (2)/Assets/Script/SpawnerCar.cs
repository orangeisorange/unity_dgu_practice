using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCar : MonoBehaviour
{
    public GameObject PrefabCar1;
    public GameObject PrefabSpace;
    public GameObject PrefabOldCar;

    private float nextTime = 0.0f;
    public float spawnRate = 0.5f;

    public Road road;
    // Start is called before the first frame update
    void Start()
    {
        road = GameObject.Find("Road").GetComponent<Road>();
    }

    // Update is called once per frame
    void Update()
    {
        // 스폰 Rate가 계속 더해져서 Time.time 보다 커지면, 적 생성.
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
        // Random을 이용하여, 3가지의 적들 중, 랜덤으로 하나 스폰되도록 함.
        // 각 적마다 스폰되는 좌표가 달라서, 스폰시 보정되는 좌표는 적 마다 다름.
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
