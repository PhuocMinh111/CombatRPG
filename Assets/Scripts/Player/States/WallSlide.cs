
using UnityEngine;


public class PlayerWallSlide : PlayerState
{
    public PlayerWallSlide(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName) : base(_player, playerStateMachine, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
        player.transform.position = new Vector2(player.transform.position.x + 0.5f * player.FacingDir, player.transform.position.y);
    }

    public override void Update()
    {
        base.Update();
        rb.velocity = new UnityEngine.Vector2(0, rb.velocity.y * 0.8f);
        if (player.IsGround)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.FacingDir *= -1;
                stateMachine.ChangeState(stateMachine.AirState);
            };
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}