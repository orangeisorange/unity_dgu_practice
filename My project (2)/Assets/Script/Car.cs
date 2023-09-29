using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 5.0f;
    public float deadHeight = -5.0f;

    public GameObject Explosion;

    public Player Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 적이 일정 속도로 아래쪽으로 내려오게 하기
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        // 만일 적이 지정한 높이보다 내려간다면, 적 없애기
        if(transform.position.y < deadHeight)
        {
            Destroy(gameObject);
        }
        // 적끼리의 충돌로 인해, 적이 공중에 솟구치는 경우가 간혹 존재. 만일 그런 상황에서 특정 범위를 벗어나면, 적 삭제
        if(transform.position.y > 14 || transform.position.x > 20 || transform.position.x < -20)
        {
            Destroy(gameObject);
        }

    }
    // 플레이어가 적에게 부딪힐 경우, 이 함수의 명령을 실행
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(gameObject.CompareTag("Space"))
            {
                Instantiate(Explosion, transform.position + new Vector3(2, 0, 9f), transform.rotation);
            }
            else if(gameObject.CompareTag("OldCar"))
            {
                Instantiate(Explosion, transform.position + new Vector3(2, 0, 7f), transform.rotation);
            }
            else
            {
                Instantiate(Explosion, transform.position + new Vector3(0, -3, -10), transform.rotation);
            }
            Destroy(gameObject);

            Player.health -= 0.1f;
        }
    }
}
