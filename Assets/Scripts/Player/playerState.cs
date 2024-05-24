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
    }

    public virtual void Enter()
    {

        this.player.PlayerAnimator.SetBool(animBoolName, true);

    }
    public virtual void Update()
    {
        CheckInput();
        IsGround = player.IsGround;

    }
    public virtual void Exit()
    {

        this.player.PlayerAnimator.SetBool(animBoolName, false);
    }



    void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }


    protected void SetVelocity()
    {
        this.player.SetVelocity(xInput * this.player.MoveSpeed, yInput * this.player.JumpForce);
    }

}
