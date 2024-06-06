using UnityEngine;

public class PlayerSlideState : PlayerState
{
    public PlayerSlideState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName) : base(_player, playerStateMachine, _animBoolName)
    {
    }
    private float _currentSlideTime = 0;
    private float _slideIncreaser = 0.5f;
    private int _maxSlides = 3;
    private float _canMoveThreshold = .8f;
    private int _slideTaken = 0;
    public override void Enter()
    {
        base.Enter();
        _currentSlideTime = player.SlideDuration;
        Slide(_currentSlideTime);

    }
    public override void Update()

    {
        base.Update();

        _currentSlideTime -= Time.deltaTime;
        if (player.SlideTimer.IsTimeOut)
        {

            if (xInput != 0)
            {
                stateMachine.ChangeState(stateMachine.MoveState);

                // out slide
            }
            // In sliding
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
                if (Input.GetKeyDown(KeyCode.LeftShift) && player.SlideDuration - _currentSlideTime < _canMoveThreshold)
                {
                    Slide(_slideIncreaser);
                }
            }
        }
        else
        {
            if (xInput != 0 && _currentSlideTime < _canMoveThreshold)
            {
                stateMachine.ChangeState(stateMachine.MoveState);
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

