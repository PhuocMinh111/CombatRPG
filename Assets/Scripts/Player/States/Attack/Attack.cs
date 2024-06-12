using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    private int comboClick = 0;
    private int attacksNumber;
    private bool clickedInframe;
    private float lastTimeAttack;
    private float comboWindow = 1f;
    public AttackState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
        PlayerState Attack1 = new(_player, _playerStateMachine, GetAnim(Anim.Attack1));
        PlayerState Attack2 = new(_player, _playerStateMachine, GetAnim(Anim.Attack2));
        PlayerState Attack3 = new(_player, _playerStateMachine, GetAnim(Anim.Attack3));
        AddSubState(Attack1);
        AddSubState(Attack2);
        attacksNumber = SubStates.Count;
        this.CurrentSubState = Attack1;
    }
    public override void Enter()
    {
        base.Enter();

        playerAnimator.SetInteger("ComboCounter", comboClick);
        clickedInframe = false;
    }

    public override void Exit()
    {
        base.Exit();



        lastTimeAttack = Time.time;
        Debug.Log("lastTimeAttack " + lastTimeAttack);
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Debug.Log("combo counter " + comboClick);

    }
    public override void Update()
    {
        base.Update();



        if (animationTrigger)
        {
            if (comboClick > 0)
            {
                if (Time.time > lastTimeAttack + comboWindow)
                    comboClick = 0;

                playerAnimator.SetInteger("ComboCounter", comboClick);
            }
            else
            {

                if (xInput == 0)
                    ChangeState(stateMachine.IdleState);
                else
                    ChangeState(stateMachine.MoveState);
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("combo clicked ");
                if (!clickedInframe)
                {
                    comboClick++;
                    clickedInframe = true;
                }
            }
        }

    }
    public void Attack()
    {
        if (comboClick > attacksNumber)
            comboClick = 0;

        playerAnimator.SetInteger("ComboCounter", comboClick);
    }

}
