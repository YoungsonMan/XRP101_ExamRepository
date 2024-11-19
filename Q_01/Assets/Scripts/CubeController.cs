using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] public Vector3 SetPoint; 
    // 그냥 인스펙터에서 3,0,3 조정하기
    public void SetPosition()
    {
        transform.position = SetPoint;
    }
}
