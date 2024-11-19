using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;

    // AttackCounter를 만들어서 어택수가 올라가면 다음 스테이트로 가게 해보기
    private int _attackCount = 0;
    private int _prevAttackCount;

    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
        _prevAttackCount = _attackCount;
    }

    public override void Enter()
    {
        Controller.StartCoroutine(DelayRoutine(Attack));
    }

    public override void OnUpdate()
    {
        

        Debug.Log("Attack On Update");
        if (_attackCount > _prevAttackCount) // 친횟수가 전에친횟수보다 크면 넘어가기
        {
            Debug.Log($"친횟수 로직 : \t 친횟수:{_attackCount} | 전횟수:{_prevAttackCount}");
            Exit();
            Debug.Log("StateExit : 아이들로");
        }
    }

    public override void Exit()
    {
        Machine.ChangeState(StateType.Idle);
    }

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)
        {
            damagable = col.GetComponent<IDamagable>();
            damagable.TakeHit(Controller.AttackValue);
            if (damagable == col.GetComponent<IDamagable>())
            {
                _prevAttackCount = _attackCount; //횟수 갱신
                Debug.Log($"PrevAttackCount : {_prevAttackCount}");
                _attackCount++; // 친횟수 ++
                Debug.Log($"AttackCount : {_attackCount}");
            }
        }
    }

    public IEnumerator DelayRoutine(Action action)
    {
        Debug.Log("어택 기다리는 코루틴 시작");
        yield return _wait;
        Debug.Log($"{_delay}초 경과,  공격!");
        Attack();
        Debug.Log("2초지나고 어택");
        Exit(); // Exit에 Idle 있는데 왜 안가는건가...
        Debug.Log("AttackStateEXit => IdleState로 진입하기");
    }

}
