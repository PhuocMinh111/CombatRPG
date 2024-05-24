using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName) : base(_player, playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        base.Update();
        SetVelocity();

        if (xInput != 0)
        {
            player.SpriteRenderer.flipX = xInput < 0;
            if (yInput > 0)
            {
                playerStateMachine.ChangeState(playerStateMachine.JumpState);
            }

        }
        else if (xInput == 0)
            playerStateMachine.ChangeState(playerStateMachine.IdleState);

    }
    public override void Exit()
    {
        base.Exit();
    }
}
