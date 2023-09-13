using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float speed = 0.1f;

    public float roadWidth = 8.0f;
    public float roadHeight = 8.0f;

//    public float x = 0.0f;
    public float y = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        y += Time.deltaTime * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -y);
    }
}
