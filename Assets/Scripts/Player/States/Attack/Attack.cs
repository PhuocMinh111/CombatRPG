using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{

    private int comboCounter = 0;
    private int comboNumber;
    private float lastTimeAttack;
    private float comboWindow = 1f;
    public AttackState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {


        comboNumber = 2;

    }
    public override void Enter()
    {
        base.Enter();
        if (comboCounter > comboNumber || Time.time >= lastTimeAttack + comboWindow)
            comboCounter = 0;



        playerAnimator.SetInteger("Combo", comboCounter);

    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Debug.Log("combo counter " + comboCounter);
        // Debug.Log("combo counter " + comboCounter);

    }

    public override void Exit()
    {
        base.Exit();

        lastTimeAttack = Time.time;
        comboCounter++;


        // Debug.Break();

    }

    public override void Update()
    {
        base.Update();

        if (animationTrigger)
            stateMachine.ChangeState(stateMachine.IdleState);

    }

}
