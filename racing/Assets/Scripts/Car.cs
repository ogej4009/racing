using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
    RequireComponent(typeof(Rigidbody)),
]
public class Car : MonoBehaviour
{
    private float moveSpeed = 1f;
    private Rigidbody rb;
    private float gasMax = 100f;   
    private float gasGauge;
    
    // 가스는 중앙 왼쪽 오른쪽 세군데 한곳에서 랜덤으로 스폰 
    // 이 가스 아이템은 자동차와 충돌하면 차량의 가스가 30증가 
    // 
    // 게임시작시 가스 100
    // 1초에 1만큼 이동 10가스를 소모 
    // 가스가 0이 되면 게임 종료
    // 게임 종료 패널이 나타난다. 
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A Key was pressed");
            rb.AddForce(Vector3.left * moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D Key was pressed");
            rb.AddForce(Vector3.right * moveSpeed);
        }
    }
}
