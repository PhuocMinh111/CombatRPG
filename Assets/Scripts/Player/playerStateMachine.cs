using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Anim
{
  Jump,
  Idle,
  Move,
  Slide,
  Dash,
  MovingAttack


};
public class PlayerStateMachine
{
  public static string GetAnim(Anim animBoolNames)
  {
    return animBoolNames.ToString();
  }
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
    IdleState = new PlayerIdleState(player, this, GetAnim(Anim.Idle));
    MoveState = new PlayerMoveState(player, this, GetAnim(Anim.Move));
    JumpState = new PlayerJumpState(player, this, GetAnim(Anim.Jump));
    SlideState = new PlayerSlideState(player, this, GetAnim(Anim.Slide));

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

  public void ChangeSubState(Anim anim)
  {
    var subState = currentState.GetSubState(anim);
    if (subState != null)
    {
      currentState.CurrentSubState.Exit();
      currentState.CurrentSubState = subState;
      currentState.CurrentSubState.Enter();
    }
  }
}
