using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField] [field: Range(0, 30)] public float AttackRadius { get; private set; }
    [field: SerializeField] public int AttackValue { get; private set; }

    [SerializeField] private StateMachine _state;
    // È®ÀÎ¿ë

    
    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _state.OnUpdate();

        
    }

    private void Init()
    {
        _state = new StateMachine(new StateIdle(this), new StateAttack(this));
    }
}
