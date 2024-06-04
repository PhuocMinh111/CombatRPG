using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AnimBoolNames
{
  Jump,
  Idle,
  Move,
  Slide,
  Dash


};
public class PlayerStateMachine
{
  private PlayerState currentState;
  private Player player;

  public PlayerState IdleState { get; private set; }
  public PlayerState MoveState { get; private set; }
  public PlayerState JumpState { get; private set; }

  public PlayerState SlideState { get; private set; }
  public PlayerState AttackState { get; private set; }

  public PlayerState CurrentState
  {
    get { return currentState; }
  }
  public PlayerStateMachine(Player player)
  {
    IdleState = new PlayerIdleState(player, this, "Idle");
    MoveState = new PlayerMoveState(player, this, "Move");
    JumpState = new PlayerJumpState(player, this, "Jump");
    SlideState = new PlayerSlideState(player, this, "Slide");

    Initialize(IdleState);
  }
  public void Initialize(PlayerState _startState)
  {

    currentState = _startState;
    currentState.Enter();
  }

  public void ChangeState(PlayerState _newState)
  {
    currentState.Exit();
    if (currentState.CurrentSubState != null)
    {
      currentState.CurrentSubState.Exit();
    }
    currentState = _newState;
    currentState.Enter();
  }

  public void ChangeSubState(PlayerState _subState)
  {
    if (currentState.CurrentSubState != null)
    {
      currentState.CurrentSubState.Exit();
      currentState.CurrentSubState = _subState;
      currentState.CurrentSubState.Enter();
    }
  }
}
