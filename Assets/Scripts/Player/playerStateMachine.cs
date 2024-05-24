using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
  private PlayerState currentState;
  private Player player;

  public PlayerState IdleState { get; private set; }
  public PlayerState MoveState { get; private set; }
  public PlayerState JumpState { get; private set; }

  public PlayerState CurrentState
  {
    get { return currentState; }
  }
  public PlayerStateMachine(Player player)
  {
    IdleState = new PlayerIdleState(player, this, "Idle");
    MoveState = new PlayerMoveState(player, this, "Move");
    JumpState = new PlayerJumpState(player, this, "Jump");

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
    currentState = _newState;
    currentState.Enter();
  }
}
