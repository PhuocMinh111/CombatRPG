using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

interface IPlayerState
{
    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
public class PlayerState : IPlayerState
{
    #region protected
    protected PlayerStateMachine playerStateMachine;
    protected bool IsGround;
    protected float xInput;
    protected float yInput;
    protected Rigidbody2D rb;
    protected Animator playerAnimator;

    #endregion
    public string State { get; set; }

    protected Player player;
    private string animBoolName;


    public PlayerState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName)
    {
        this.player = _player;
        this.playerStateMachine = playerStateMachine;
        this.animBoolName = _animBoolName;
        rb = _player.Rigidbody2D;
        playerAnimator = _player.PlayerAnimator;
    }

    public virtual void Enter()
    {

        this.player.PlayerAnimator.SetBool(animBoolName, true);

    }
    public virtual void Update()
    {

        IsGround = player.IsGround;
        xInput = player.xInput;
        yInput = player.yInput;

    }
    public virtual void Exit()
    {

        playerAnimator.SetBool(animBoolName, false);
    }





    protected void SetVelocity()
    {
        this.player.SetVelocity(xInput * this.player.MoveSpeed, yInput * this.player.JumpForce);
    }

}
