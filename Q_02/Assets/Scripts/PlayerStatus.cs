using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] public float MoveSpeed;
  //  public float MoveSpeed
  // {
  //     get => MoveSpeed;
  //     private set => MoveSpeed = value;
  // }

    private void Awake()
    {
        MoveSpeed = 0;
        
    }
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
