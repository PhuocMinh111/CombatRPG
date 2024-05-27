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
        rb.velocity = new Vector2(xInput * player.MoveSpeed, rb.velocity.y);

        if (xInput != 0)
        {

            if (Input.GetKeyDown(KeyCode.Space) && player.GroundCheck())
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
