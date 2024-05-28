using UnityEngine;

public class PlayerSlideState : PlayerState
{
    public PlayerSlideState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName) : base(_player, playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.Slide(player.SlideDuration);
    }
    public override void Update()
    {
        base.Update();
        if (!player.IsGround || !player.IsSliding)
        {
            if (xInput != 0)
            {
                playerStateMachine.ChangeState(playerStateMachine.MoveState);
            }
            else
            {

                playerStateMachine.ChangeState(playerStateMachine.IdleState);
            }
        }

    }

    public override void Exit()
    {
        base.Exit();
    }


}

