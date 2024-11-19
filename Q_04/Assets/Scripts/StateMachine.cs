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
        // states[0] 이 처음 상태인데
        // StateAttack 가면서 공격상태인 1로가는데 
        // StateIdle 로 가려고 바꾸는데 [0]으로 안가고 [1]에서 올라가서 그런건가..?
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
