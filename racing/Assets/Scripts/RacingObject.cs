using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingObject : MonoBehaviour
{
    private bool bTerminationCondition {get; set; }
    
    public Action<GameObject> OnDestroyed;
    //Termination Conditions 
    // 게임시작시 가스 100
    // 1초에 1만큼 이동 10가스를 소모 
    // 가스가 0이 되면 게임 종료
    private void Update()
    {
        if (bTerminationCondition)
            DestroyObj();
    }

    private void DestroyObj()
    {
        OnDestroyed?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
