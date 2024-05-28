using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName) : base(_player, playerStateMachine, _animBoolName)
    {
    }
    private bool _canDoubleJump = true;

    public override void Enter()
    {
        base.Enter();
        player.Jump(1);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        playerAnimator.SetFloat("yVelocity", yInput);

        if (player.IsGround)
        {
            _canDoubleJump = true;
            if (rb.velocity.y == 0)
                playerStateMachine.ChangeState(playerStateMachine.IdleState);
        }
        else
        {
            player.MoveHorizontally(xInput);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!_canDoubleJump) return;
                _canDoubleJump = false;
                player.Jump(1.2f);
            }
        }

    }
}
