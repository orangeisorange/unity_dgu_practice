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
        // �巳���� ���� �ö󰡰� �ϱ�
        transform.Translate(Vector3.up * speed * Time.deltaTime) ;
        // ��� �� �̻����� �ö󰡸� �巳�� ����
        if(transform.position.y > deadHeight )
        {
            Destroy(gameObject);
        }
    }
}
