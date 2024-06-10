using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : PlayerState
{
    public Attack(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
        PlayerState Attack1 = new(_player, _playerStateMachine, GetAnim(Anim.Attack1));
        PlayerState Attack2 = new(_player, _playerStateMachine, GetAnim(Anim.Attack2));
        PlayerState Attack3 = new(_player, _playerStateMachine, GetAnim(Anim.Attack3));
        AddSubState(Attack1);
        AddSubState(Attack2);
        AddSubState(Attack3);
        this.CurrentSubState = Attack1;
    }
    public override void Enter()
    {
        base.Enter();
        ChangeSubState(Anim.Attack1);
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        if (animationTrigger)
            stateMachine.ChangeState(stateMachine.IdleState);


    }
}
