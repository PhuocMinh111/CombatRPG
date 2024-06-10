using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    PlayerState DashState;

    public PlayerAirState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName) : base(_player, playerStateMachine, _animBoolName)
    {
        DashState = new PlayerDashState(_player, playerStateMachine, GetAnim(Anim.Dash));
        this.CurrentSubState = DashState;
    }

    private bool _canDoubleJump = true;

    public override void Enter()
    {
        base.Enter();

        Jump(1);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        playerAnimator.SetFloat("yVelocity", yInput);
        rb.velocity = new Vector2(player.MoveSpeed * player.FacingDir, rb.velocity.y);


        if (player.IsGround)
        {
            _canDoubleJump = true;
            if (rb.velocity.y == 0)
                stateMachine.ChangeState(stateMachine.IdleState);
        }
        else
        {
            if (player.IsHitWall)
            {
                stateMachine.ChangeState(stateMachine.WallSlideState);
            }
        }


        // if (!DashState.IsActive)
        // player.MoveHorizontally(xInput);

        if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump)
        {

            _canDoubleJump = false;
            Jump(1.2f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }


    }
    void Jump(float _yVelocity)
    {
        rb.velocity = new Vector2(player.MoveSpeed * player.FacingDir, _yVelocity * player.JumpForce);
    }
    void Dash()
    {
        PlayerState DashState = GetSubState(Anim.Dash);
        if (DashState != null)
            ChangeSubState(Anim.Dash);

    }
}
