using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 5.0f;
    public float deadHeight = -5.0f;

    public GameObject Explosion;


    // Start is called before the first frame update
    void Start()
    {
        
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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(gameObject.CompareTag("Space"))
            {
                Debug.Log("space");
                Instantiate(Explosion, transform.position + new Vector3(2, 0, 7f), transform.rotation);
            }
            else if(gameObject.CompareTag("OldCar"))
            {
                Debug.Log("Oldcar");
                Instantiate(Explosion, transform.position + new Vector3(2, 0, 7f), transform.rotation);
            }
            else
            {
                Instantiate(Explosion, transform.position + new Vector3(0, -3, -10), transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
