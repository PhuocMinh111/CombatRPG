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



            player.MoveHorizontally(xInput);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                stateMachine.ChangeState(stateMachine.SlideState);

            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.ChangeState(stateMachine.AirState);
            }
            else if (Input.GetMouseButton(1))
            {
                ChangeSubState(Anim.MovingAttack);
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
