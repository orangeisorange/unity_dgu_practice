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
        // 아이템이 움직이는 속도는 랜덤.
        speed = Random.Range(speed-offset, speed +  offset);
    }

    // Update is called once per frame
    void Update()
    {
        // 아이템이 일정 높이 이하로 가게 된다면, 아이템 삭제
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < deadHeight) 
        {
            Destroy(gameObject);
        }
    }
}
