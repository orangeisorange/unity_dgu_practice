using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float speed = 5.0f;
    private float deadHeight = 11.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 드럼통이 위로 올라가게 하기
        transform.Translate(Vector3.up * speed * Time.deltaTime) ;
        // 어느 선 이상으로 올라가면 드럼통 삭제
        if(transform.position.y > deadHeight )
        {
            Destroy(gameObject);
        }
    }
}
