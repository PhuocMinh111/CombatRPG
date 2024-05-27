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
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();

        if (yInput > 0)
        {

            playerStateMachine.ChangeState(playerStateMachine.JumpState);
        }
        else if (xInput != 0)
        {

            playerStateMachine.ChangeState(playerStateMachine.MoveState);

        }
    }
}
