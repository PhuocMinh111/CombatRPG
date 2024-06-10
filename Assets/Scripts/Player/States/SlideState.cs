using UnityEngine;

public class PlayerSlideState : PlayerState
{
    public PlayerSlideState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName) : base(_player, playerStateMachine, _animBoolName)
    {
    }
    private float _currentSlideTime = 0;
    private float _slideDuration;
    private float _slideIncreaser = 0.5f;
    private int _maxSlides = 3;
    private float _canMoveThreshold = .8f;
    private int _slideTaken = 0;
    private float _slideCooldown = 0;


    public override void Enter()
    {
        base.Enter();
        _slideCooldown = player.SlideDuration;
        _currentSlideTime = player.SlideDuration;
        rb.velocity = new Vector2(player.SlideSpeed * player.FacingDir, rb.velocity.y);

    }
    public override void Update()

    {
        base.Update();
        _slideCooldown -= Time.deltaTime;


        if (_slideCooldown > 0)
        {

            if (xInput != 0 && _slideCooldown < _canMoveThreshold)
            {
                stateMachine.ChangeState(stateMachine.MoveState);
            }
            // In sliding

        }
        else
        {
            if (xInput != 0)
                stateMachine.ChangeState(stateMachine.MoveState);
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

    private void Slide(float time)
    {
        UpdateSlideTime(time);

        ++_slideTaken;

        if (_slideTaken > _maxSlides)
        {
            _slideTaken = 0;
            return;
        }
        else
        {
            float dir = player.FacingRight ? 1 : -1;

            rb.velocity = new Vector2(player.SlideSpeed * dir, rb.velocity.y);


        }
    }

    private void UpdateSlideTime(float time)
    {

        if (player.SlideTimer.IsTimeOut)
            player.SlideTimer.SetTimer(time);


    }

}

