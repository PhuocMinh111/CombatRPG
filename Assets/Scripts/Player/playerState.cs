using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

interface IPlayerState {
    public virtual void Enter () {}
    public virtual void Exit () {}
    public virtual void Update () {}
}
public  class PlayerState:IPlayerState
{
  #region protected
    protected PlayerStateMachine playerStateMachine;
    
    protected float xInput;
    protected Rigidbody2D rb;

 #endregion
    public string state {get;set;}

    protected Player player;
    private string animBoolName;
    public PlayerState(Player _player,PlayerStateMachine playerStateMachine,string _animBoolName)
    {
        this.player = _player;
        this.playerStateMachine = playerStateMachine;
        this.animBoolName = _animBoolName;
    }
    
    public virtual void Enter ()
    {   
        rb = player.Rigidbody2D;
        this.player.PlayerAnimator.SetBool(animBoolName,true);
        Debug.Log("enter " + animBoolName);
    }
    public virtual void Update () {
        xInput = Input.GetAxisRaw("Horizontal");
        
SetVelocity();
    }
    public virtual void Exit()
    {
       
        this.player.PlayerAnimator.SetBool(animBoolName,false);
    }
    

    
    
    

    void SetVelocity ()
    {
        this.player.SetVelocity(xInput*this.player.MoveSpeed,rb.velocity.y);
    }
   
}
