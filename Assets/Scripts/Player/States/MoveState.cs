using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName) : base(_player, playerStateMachine, _animBoolName)
    {
        this.CurrentSubState = new PlayerMovingAttack(_player, playerStateMachine, GetAnim(Anim.MovingAttack));
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Update()
    {
        base.Update();


        if (xInput != 0)
        {

            if (player.IsGround)
            {


                player.MoveHorizontally(xInput);
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    stateMachine.ChangeState(stateMachine.SlideState);

                }
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    stateMachine.ChangeState(stateMachine.JumpState);
                }
                else if (Input.GetMouseButton(1))
                {
                    stateMachine.ChangeSubState(Anim.MovingAttack);
                }
            }
            else if (!player.IsGround && player.IsHitWall)
            {
                stateMachine.ChangeState(stateMachine.WallSlideState);
            }

        }
        else if (xInput == 0)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }

    }



    public override void Exit()
    {
        base.Exit();
    }
}
