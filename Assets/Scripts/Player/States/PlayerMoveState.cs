using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerMoveState : PlayerState
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

        if (xInput ==0)
            playerStateMachine.ChangeState(player.IdleState);
        
    }
    public override void Exit()
    {
        base.Exit();
    }
}
