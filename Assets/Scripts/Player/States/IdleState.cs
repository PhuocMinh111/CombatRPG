using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName) : base(_player, playerStateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        rb.velocity = Vector2.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();

        if (xInput == 0)
        {
            Debug.Log(xInput);
            if (Input.GetKeyDown(KeyCode.Space) && player.IsGround)
            {

                stateMachine.ChangeState(stateMachine.AirState);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && player.SlideTimer.IsTimeOut)
            {
                stateMachine.ChangeState(stateMachine.SlideState);
            }
        }
        else if (xInput != 0)
        {

            stateMachine.ChangeState(stateMachine.MoveState);

        }

    }
}
