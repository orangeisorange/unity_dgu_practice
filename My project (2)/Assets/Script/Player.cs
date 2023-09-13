using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 10.0f;

    public bool bItemReverse = false;
    public float timeItemReverse;
    private float timeItemReverseStart;
    // Start is called before the first frame update
    public Road road;
    void Start()
    {
        road = GameObject.Find("Road").GetComponent<Road>();

        bItemReverse = false;
        timeItemReverse = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float dir1 = Input.GetAxis("Horizontal");

        if (bItemReverse)
            dir1 *= -1;

        transform.Translate(Vector3.right * dir1 * speed * Time.deltaTime);

        float dir2 = Input.GetAxis("Vertical");

        if(bItemReverse)
            dir2 *= -1;
        transform.Translate(Vector3.up * dir2 * speed * Time.deltaTime);

        if(bItemReverse)
        {
            if(Time.time - timeItemReverseStart > timeItemReverse)
            {
                bItemReverse = false;
            }
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
    }
}
