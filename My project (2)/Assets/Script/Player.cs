using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 10.0f;
    // Start is called before the first frame update
    public Road road;
    void Start()
    {
        road = GameObject.Find("Road").GetComponent<Road>();
    }

    // Update is called once per frame
    void Update()
    {
        float dir1 = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * dir1 * speed * Time.deltaTime);

        float dir2 = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * dir2 * speed * Time.deltaTime);

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
}
