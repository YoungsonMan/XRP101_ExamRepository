using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;

    // AttackCounter�� ���� ���ü��� �ö󰡸� ���� ������Ʈ�� ���� �غ���
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
        if (_attackCount > _prevAttackCount) // ģȽ���� ����ģȽ������ ũ�� �Ѿ��
        {
            Debug.Log($"ģȽ�� ���� : \t ģȽ��:{_attackCount} | ��Ƚ��:{_prevAttackCount}");
            Exit();
            Debug.Log("StateExit : ���̵��");
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
                _prevAttackCount = _attackCount; //Ƚ�� ����
                Debug.Log($"PrevAttackCount : {_prevAttackCount}");
                _attackCount++; // ģȽ�� ++
                Debug.Log($"AttackCount : {_attackCount}");
            }
        }
    }

    public IEnumerator DelayRoutine(Action action)
    {
        Debug.Log("���� ��ٸ��� �ڷ�ƾ ����");
        yield return _wait;
        Debug.Log($"{_delay}�� ���,  ����!");
        Attack();
        Debug.Log("2�������� ����");
        Exit(); // Exit�� Idle �ִµ� �� �Ȱ��°ǰ�...
        Debug.Log("AttackStateEXit => IdleState�� �����ϱ�");
    }

}
