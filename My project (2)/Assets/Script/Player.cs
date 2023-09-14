using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 10.0f;

    public static float health;

    public bool bItemReverse = false;
    public float timeItemReverse;
    private float timeItemReverseStart;

    public bool bItemBullet = false;
    private float timeItemBullet;
    private float timeItemBulletStart;

    public bool bItemOil = false;
    private float timeItemOil;
    private float timeItemOilStart;

    public bool bItemHealth = false;
    private float timeItemHealth;
    private float timeItemHealthStart;

    public bool bItemBomb = false;

    public bool bItemMagnet = false;
    private float timeItemMagnet;
    private float timeItemMagnetStart;

    public GameObject PrefabBarrel;
    // Start is called before the first frame update
    public Road road;
    void Start()
    {
        road = GameObject.Find("Road").GetComponent<Road>();

        health = 1.0f;

        bItemReverse = false;
        timeItemReverse = 5.0f;

        bItemBullet = false;
        timeItemBullet = 5.0f;

        bItemOil = false;
        timeItemOil = 5.0f;
        
        bItemHealth = false;
        timeItemHealth = 5.0f;

        bItemBomb = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dir1 = Input.GetAxis("Horizontal");

        if (bItemReverse)
            dir1 *= -1;
        if (bItemOil)
            dir1 *= 10;
        transform.Translate(Vector3.right * dir1 * speed * Time.deltaTime);

        float dir2 = Input.GetAxis("Vertical");

        if(bItemReverse)
            dir2 *= -1;
        if(bItemOil)
            dir2 *= 10;
        transform.Translate(Vector3.up * dir2 * speed * Time.deltaTime);

        if(bItemReverse)
        {
            if(Time.time - timeItemReverseStart > timeItemReverse)
            {
                bItemReverse = false;
            }
        }

        if(bItemOil)
        {
            if(Time.time - timeItemOilStart > timeItemOil)
            {
                bItemOil = false;
            }
        }
        if (bItemBullet)
        {
            if(Time.time - timeItemBulletStart > timeItemBullet)
            {
                bItemBullet = false;
            }
            if(Input.GetKeyDown("space"))
            {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 1.8f, transform.position.z - 12);
                Instantiate(PrefabBarrel, newPos, Quaternion.identity);
            }
        }
        if(bItemHealth)
        {
            if(Time.time - timeItemHealthStart > timeItemHealth)
            {
                bItemHealth = false;
            }
        }
        if (bItemBomb)
        {
            // "Enemy" 태그를 가진 모든 GameObject들을 찾아서 제거합니다.
            GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemyObjects)
            {
                Destroy(enemy);
            }

            // "Space" 태그를 가진 모든 GameObject들을 찾아서 제거합니다.
            GameObject[] spaceObjects = GameObject.FindGameObjectsWithTag("Space");
            foreach (GameObject space in spaceObjects)
            {
                Destroy(space);
            }

            // "OldCar" 태그를 가진 모든 GameObject들을 찾아서 제거합니다.
            GameObject[] oldCarObjects = GameObject.FindGameObjectsWithTag("OldCar");
            foreach (GameObject oldCar in oldCarObjects)
            {
                Destroy(oldCar);
            }
            bItemBomb = false;
        }

        if(transform.position.x < -road.roadWidth)
        {
            transform.position = new Vector3(-road.roadWidth, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > road.roadWidth)
        {
            transform.position = new Vector3(road.roadWidth, transform.position.y, transform.position.z);
        }
        else if (transform.position.y > road.roadHeight)
        {
            transform.position = new Vector3(transform.position.x, road.roadHeight, transform.position.z);
        }
        else if (transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item_Reverse")
        {
            Destroy(other.gameObject);
            bItemReverse = true;
            timeItemReverseStart = Time.time;
        }
        if (other.tag == "Item_Oil")
        {
            Destroy(other.gameObject);
            bItemOil = true;
            timeItemOilStart = Time.time;
        }
        if (other.tag == "Item_Bullet")
        {
            Destroy(other.gameObject);
            bItemBullet = true;
            timeItemBulletStart = Time.time;
        }
        if (other.tag == "Item_Health")
        {
            Destroy(other.gameObject);
            bItemHealth = true;
            timeItemHealthStart = Time.time;

            health += 0.1f;
            health = Mathf.Clamp(health, 0.1f, 1.0f);
        }
        if (other.tag == "Item_Bomb")
        {
            Destroy(other.gameObject);
            bItemBomb = true;
        }
        if (other.tag == "Item_Magnet")
        {
            Destroy(other.gameObject);
            bItemMagnet = true;
            timeItemMagnetStart = Time.time;
        }
    }
}
