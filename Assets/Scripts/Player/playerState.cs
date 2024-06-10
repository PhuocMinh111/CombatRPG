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

    #region public

    public PlayerState GetSubState(Anim key)
    {
        PlayerState subState;
        if (this.SubStates.TryGetValue(GetAnim(key), out subState))
        {
            return subState;
        }
        else
        {
            return null;
        }
    }



    #endregion



    #region protected
    protected PlayerStateMachine stateMachine;
    protected bool IsGround;
    protected float xInput;
    protected float yInput;
    protected Rigidbody2D rb;
    protected Animator playerAnimator;

    protected Player player;
    private string animBoolName;
    protected bool animationTrigger;
    protected Dictionary<string, PlayerState> _subStates = new Dictionary<string, PlayerState>();
    protected PlayerState _currentSubState = null;

    protected void ChangeSubState(Anim anim)
    {
        var subState = GetSubState(anim);
        if (subState != null)
        {
            CurrentSubState.Exit();
            CurrentSubState = subState;
            CurrentSubState.Enter();
        }
    }
    protected void AddSubState(PlayerState substate)
    {
        SubStates.Add(substate.animBoolName, substate);
    }
    protected string GetAnim(Anim anim)
    {
        return PlayerStateMachine.GetAnim(anim);
    }

    #endregion

    #region property
    public string State { get; set; }

    public bool IsActive { get; set; }

    public Dictionary<string, PlayerState> SubStates
    {
        get { return _subStates; }
        set { _subStates = value; }

    }
    public PlayerState CurrentSubState
    {
        get { return _currentSubState; }
        set
        {
            if (value != null)
            {
                if (SubStates.TryGetValue(value.animBoolName, out _currentSubState)) return;
                _currentSubState = value;
                SubStates.Add(value.animBoolName, value);
            }
        }
    }

    #endregion

    public PlayerState(Player _player, PlayerStateMachine playerStateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = playerStateMachine;
        this.animBoolName = _animBoolName;
        rb = _player.Rigidbody2D;
        IsActive = false;
        playerAnimator = _player.PlayerAnimator;
    }

    public virtual void Enter()
    {
        Debug.Log("enter " + animBoolName);
        IsActive = true;
        animationTrigger = false;
        playerAnimator.SetBool(animBoolName, true);

    }
    public virtual void Update()
    {

        Debug.Log("Update " + this.animBoolName);
        xInput = player.xInput;
        yInput = player.yInput;

    }
    public virtual void Exit()
    {
        IsActive = false;
        playerAnimator.SetBool(animBoolName, false);
    }


    public virtual void OnAnimationTrigger() => animationTrigger = true;

    protected void SetAnimBool(string _animBoolName, bool _bool)
    {
        if (playerAnimator.GetBool(_animBoolName))
        {
            playerAnimator.SetBool(_animBoolName, _bool);
        }
    }



}
