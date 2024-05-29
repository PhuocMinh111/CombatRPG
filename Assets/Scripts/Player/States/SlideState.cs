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
        float dir = player.FacingRight ? 1 : -1;
        rb.velocity = new Vector2(player.SlideSpeed * dir, rb.velocity.y);
        Debug.Log("In slide " + player.SlideTimer.IsTimeOut);

    }
    public override void Update()
    {
        base.Update();


        if (player.SlideTimer.IsTimeOut)
        {
            // Debug.Break();
            if (!player.IsGround)
            {
                stateMachine.ChangeState(stateMachine.JumpState);
            }
            if (xInput != 0)
            {
                stateMachine.ChangeState(stateMachine.MoveState);
            }
            else
            {

                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }

    }

    public override void Exit()
    {
        base.Exit();
    }


}

