using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    public GameObject ItemReverse;
    public GameObject ItemOil;
    public GameObject ItemBullet;
    public GameObject ItemHealth;
    public GameObject ItemBomb;
    public GameObject ItemMagnet;

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
            int i = Random.Range(1, 7);
            if (i == 1)
            {
                SpawnOil();
            }
            if(i == 2)
            {
                SpawnReverse();
            }
            if (i == 3)
            {
                SpawnBullet();
            }
            if( i == 4)
            {
                SpawnHealth();
            }
            if( i ==5)
            {
                SpawnBomb();
            }
            if(i==6)
            {
                SpawnMagnet();
            }
            nextTime = Time.time + spawnRate;
        }
    }

    void SpawnReverse()
    {
        float addXPos = Random.Range(-road.roadWidth-4, road.roadWidth-4);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, -11);
        Instantiate(ItemReverse, spawnPos, Quaternion.Euler(0, 180, 0));
    }
    void SpawnOil()
    {
        float addXPos = Random.Range(-road.roadWidth - 4, road.roadWidth - 4);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, -11);
        Instantiate(ItemOil, spawnPos, Quaternion.Euler(0, 180, 0));
    }
    void SpawnBullet()
    {
        float addXPos = Random.Range(-road.roadWidth - 4, road.roadWidth - 4);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, -11);
        Instantiate(ItemBullet, spawnPos, Quaternion.Euler(0, 180, 0));
    }
    void SpawnHealth()
    {
        float addXPos = Random.Range(-road.roadWidth - 4, road.roadWidth - 4);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, -11);
        Instantiate(ItemHealth, spawnPos, Quaternion.Euler(0, 180, 0));
    }
    void SpawnBomb()
    {
        float addXPos = Random.Range(-road.roadWidth - 4, road.roadWidth - 4);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, -11);
        Instantiate(ItemBomb, spawnPos, Quaternion.Euler(0, 180, 0));
    }
    void SpawnMagnet()
    {
        float addXPos = Random.Range(-road.roadWidth - 4, road.roadWidth - 4);
        Vector3 spawnPos = transform.position + new Vector3(addXPos, 0, -11);
        Instantiate(ItemMagnet, spawnPos, Quaternion.Euler(0, 180, 0));
    }
}
