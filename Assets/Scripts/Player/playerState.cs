using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    protected PlayerStateMachine stateMachine;
    protected bool IsGround;
    protected float xInput;
    protected float yInput;
    protected Rigidbody2D rb;
    protected Animator playerAnimator;

    #endregion

    protected Player player;
    private string animBoolName;

    protected Dictionary<string, PlayerState> _subStates;
    protected PlayerState _currentSubState = null;

    #region property
    public string State { get; set; }
    public Dictionary<string, PlayerState> SubStates
    {
        get { return _subStates; }

    }
    public PlayerState CurrentSubState
    {
        get { return _currentSubState; }
        set { _currentSubState = value; }
    }

    #endregion

    public PlayerState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = playerStateMachine;
        this.animBoolName = _animBoolName;
        rb = _player.Rigidbody2D;
        playerAnimator = _player.PlayerAnimator;
    }

    public virtual void Enter()
    {
        Debug.Log("enter " + animBoolName);
        playerAnimator.SetBool(animBoolName, true);

    }
    public virtual void Update()
    {


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
