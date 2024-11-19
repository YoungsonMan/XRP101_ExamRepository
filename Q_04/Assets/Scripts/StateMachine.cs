using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle, Attack
}

public class StateMachine
{
    private Dictionary<StateType, PlayerState> _stateContainer;
    public StateType CurrentType { get; private set; }
    private PlayerState CurrentState => _stateContainer[CurrentType];

    public StateMachine(params PlayerState[] states)
    {
        _stateContainer = new Dictionary<StateType, PlayerState>();

        foreach (var s in states)
        {
            if (!_stateContainer.ContainsKey(s.ThisType))
            {
                _stateContainer.Add(s.ThisType, s);    
            }
            s.Machine = this;
        }

        CurrentType = states[0].ThisType;
        // states[0] �� ó�� �����ε�
        // StateAttack ���鼭 ���ݻ����� 1�ΰ��µ� 
        // StateIdle �� ������ �ٲٴµ� [0]���� �Ȱ��� [1]���� �ö󰡼� �׷��ǰ�..?
        // 
        CurrentState.Enter();
    }

    public void OnUpdate()
    {
        Debug.Log($" CurrentType = {CurrentType}");
        Debug.Log($" CurrentState = {CurrentState}");
        CurrentState.OnUpdate();
    }

    public void ChangeState(StateType state)
    {
        CurrentState.Exit();
        CurrentType = state;
        CurrentState.Enter();
    }
}
