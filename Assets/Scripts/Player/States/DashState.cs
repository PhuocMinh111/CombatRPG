using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName) : base(_player, playerStateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        player.Dash();
    }
    public override void Update()
    {
        base.Update();
        if (player.IsGround)
        {
            if (xInput == 0)
            {

                stateMachine.ChangeState(stateMachine.IdleState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.MoveState);
            }
        }
    }
    public override void Exit()
    {
        base.Exit();

    }
}