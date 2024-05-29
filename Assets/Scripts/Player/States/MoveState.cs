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


        if (xInput != 0)
        {
            player.MoveHorizontally(xInput);
            if (Input.GetKeyDown(KeyCode.LeftShift) && player.SlideTimer.IsTimeOut)
            {
                stateMachine.ChangeState(stateMachine.SlideState);

            }
            else if (Input.GetKeyDown(KeyCode.Space) && !player.IsSliding && player.IsGround)
            {
                stateMachine.ChangeState(stateMachine.JumpState);
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
