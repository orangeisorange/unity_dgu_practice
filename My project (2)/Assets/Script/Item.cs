using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed = 5.0f;
    private float deadHeight = -3.0f;

    public Road road;
    // Start is called before the first frame update
    void Start()
    {
        road = GameObject.Find("Road").GetComponent<Road>();
        float offset = Random.Range(0, 3.0f);
        speed = Random.Range(speed-offset, speed +  offset);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < deadHeight) 
        {
            Destroy(gameObject);
        }
    }
}
