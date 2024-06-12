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




        player.MoveHorizontally(xInput);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangeState(stateMachine.SlideState);

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeState(stateMachine.AirState);
        }
        else if (Input.GetMouseButton(1))
        {
            ChangeSubState(Anim.Attack);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            ChangeState(stateMachine.Attack);
        }



        if (xInput == 0)
        {
            ChangeState(stateMachine.IdleState);
        }

    }



    public override void Exit()
    {
        base.Exit();
    }
}
