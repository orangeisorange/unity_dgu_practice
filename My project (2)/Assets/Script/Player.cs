using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float speed = 10.0f;

    public static float health;

    public GameObject Explosion;

    public static float magnet_range;
    public static float magnetSpeed;

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

    public bool bItemSlow = false;
    private float timeItemSlow;
    private float timeItemSlowStart;

    public GameObject PrefabBarrel;
    // Start is called before the first frame update
    public Road road;
    void Start()
    {
        road = GameObject.Find("Road").GetComponent<Road>();
        health = 1.0f;

        magnet_range = 20f;
        magnetSpeed = 5.0f;

        bItemReverse = false;
        timeItemReverse = 5.0f;

        bItemBullet = false;
        timeItemBullet = 5.0f;

        bItemOil = false;
        timeItemOil = 5.0f;

        bItemHealth = false;
        timeItemHealth = 5.0f;

        bItemBomb = false;

        bItemMagnet = false;
        timeItemMagnet = 5.0f;

        bItemSlow = false;
        timeItemSlow = 5.0f;




    }

    // Update is called once per frame
    void Update()
    {
        float dir1 = Input.GetAxis("Horizontal");

        // 만일 죽을 경우, 죽은 후 보는 씬으로 씬 전환
        if (health <= 0)
        {
            SceneManager.LoadScene("diedUI");
        }


        if (bItemReverse)
            dir1 *= -1;
        if (bItemOil)
            dir1 *= 10;
        if (bItemSlow)
            dir1 /= 10;
        transform.Translate(Vector3.right * dir1 * speed * Time.deltaTime);

        float dir2 = Input.GetAxis("Vertical");

        if(bItemReverse)
            dir2 *= -1;
        if(bItemOil)
            dir2 *= 10;
        if(bItemSlow)
            dir2 /= 10;
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

        if(bItemSlow)
        {
            if(Time.time - timeItemSlowStart > timeItemSlow)
            {
                bItemSlow = false;
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
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y + 1.8f, transform.position.z - 13);
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
            // Enemy 태그를 단 모든 적을 enemyObjects 배열에 넣고, 그 위치에 Explosion 효과 실행 후, 모두 폭파
            GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemyObjects)
            {
                Instantiate(Explosion, enemy.transform.position + new Vector3(0, -3, -10), transform.rotation);
                Destroy(enemy);
            }

            // Space 태그를 단 모든 적을 enemyObjects 배열에 넣고, 그 위치에 Explosion 효과 실행 후, 모두 폭파
            GameObject[] spaceObjects = GameObject.FindGameObjectsWithTag("Space");
            foreach (GameObject space in spaceObjects)
            {
                Instantiate(Explosion, space.transform.position + new Vector3(2, 0, 9f), transform.rotation);
                Destroy(space);
            }

            // OldCar 태그를 단 모든 적을 enemyObjects 배열에 넣고, 그 위치에 Explosion 효과 실행 후, 모두 폭파
            GameObject[] oldCarObjects = GameObject.FindGameObjectsWithTag("OldCar");
            foreach (GameObject oldCar in oldCarObjects)
            {
                Instantiate(Explosion, oldCar.transform.position + new Vector3(2, 0, 7f), transform.rotation);
                Destroy(oldCar);
            }
            // 폭탄 효과는 즉발성. 지속되지 않으므로 즉시 false
            bItemBomb = false;
        }

        // 자석 효과 활성화 시, 이로운 게임 오브젝트들만 내 위치로 끌려오도록 설정하였음.
        if(bItemMagnet)
        {
            GameObject[] healthObjects = GameObject.FindGameObjectsWithTag("Item_Health");
            foreach(GameObject health in healthObjects)
            {
                // 게임 아이템과 나 사이의 거리를 잰다. 이때 범위 안에 들어와 있다면, 끌려오게 하도록 한다.
                float dis = Vector3.Distance(transform.position, health.transform.position);
                if(dis < magnet_range)
                {
                    Vector3 direction = (gameObject.transform.position - health.transform.position);
                    // z축 방향으로는 아이템이 움직일 필요가 없으므로 0으로 한다.
                    direction.z = 0;
                    // 아이템이 내쪽으로 끌려온다.
                    health.transform.position += direction.normalized * Time.deltaTime * magnetSpeed ;
                }
            }
            GameObject[] BulletObjects = GameObject.FindGameObjectsWithTag("Item_Bullet");
            foreach (GameObject Bullet in BulletObjects)
            {
                // 게임 아이템과 나 사이의 거리를 잰다. 이때 범위 안에 들어와 있다면, 끌려오게 하도록 한다.
                float dis = Vector3.Distance(transform.position, Bullet.transform.position);
                if (dis < magnet_range)
                {
                    Vector3 direction = (gameObject.transform.position - Bullet.transform.position);
                    // z축 방향으로는 아이템이 움직일 필요가 없으므로 0으로 한다.
                    direction.z = 0;
                    // 아이템이 내쪽으로 끌려온다.
                    Bullet.transform.position += direction.normalized * Time.deltaTime * magnetSpeed ;
                }
            }
            GameObject[] BombObjects = GameObject.FindGameObjectsWithTag("Item_Bomb");
            foreach (GameObject Bomb in BombObjects)
            {
                // 게임 아이템과 나 사이의 거리를 잰다. 이때 범위 안에 들어와 있다면, 끌려오게 하도록 한다.
                float dis = Vector3.Distance(transform.position, Bomb.transform.position);
                if (dis < magnet_range)
                {
                    Vector3 direction = (gameObject.transform.position - Bomb.transform.position);
                    // z축 방향으로는 아이템이 움직일 필요가 없으므로 0으로 한다.
                    direction.z = 0;
                    // 아이템이 내쪽으로 끌려온다.
                    Bomb.transform.position += direction.normalized * Time.deltaTime * magnetSpeed ;
                }
            }
            if (Time.time - timeItemMagnetStart > timeItemMagnet)
            {
                bItemMagnet = false;
            }
        }

        // 플레이어가 화면 밖으로 나가지 못하게 강제함.
        if (transform.position.x < -road.roadWidth)
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
        else if (transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, -5, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "OldCar" || other.tag == "Space")
        {
            GetComponent<AudioSource>().Play();
        }
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
            // 적이 폭발하므로, 폭발음을 실행함.
            GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            bItemBomb = true;
        }
        if (other.tag == "Item_Magnet")
        {
            Destroy(other.gameObject);
            bItemMagnet = true;
            timeItemMagnetStart = Time.time;
        }
        if(other.tag == "Item_Slow")
        {
            Destroy(other.gameObject);
            bItemSlow = true;
            timeItemSlowStart = Time.time;
        }
    }
}
