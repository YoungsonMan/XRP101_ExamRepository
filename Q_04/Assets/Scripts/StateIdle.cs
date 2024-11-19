using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIdle : PlayerState
{
    public StateIdle(PlayerController controller) : base(controller) { }

    public override void Init()
    {
        ThisType = StateType.Idle;
    }

    public override void OnUpdate()
    {
        Debug.Log("Idle On Update");

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // 테스트용 Q버튼 찍혔나 로그
            Debug.Log("Q버튼이 눌렸습니다.");

            Machine.ChangeState(StateType.Attack);
        }
    }
}
