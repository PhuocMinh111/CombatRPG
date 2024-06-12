using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Anim
{
  Air,
  Idle,
  Move,
  Slide,
  Dash,
  MovingAttack,
  WallSlide,
  Attack,
  Attack1,
  Attack2,
  Attack3,


};
public class PlayerStateMachine
{
  public static string GetAnim(Anim animBoolNames)
  {
    return animBoolNames.ToString();
  }
  private PlayerState currentState;
  private Player Player;

  public PlayerState IdleState { get; private set; }
  public PlayerState MoveState { get; private set; }
  public PlayerState AirState { get; private set; }

  public PlayerState SlideState { get; private set; }
  public PlayerState Attack { get; private set; }
  public PlayerState WallSlideState { get; private set; }


  public PlayerState CurrentState
  {
    get { return currentState; }
  }
  public PlayerStateMachine(Player player)
  {
    Player = player;
    IdleState = new PlayerIdleState(player, this, GetAnim(Anim.Idle));
    MoveState = new PlayerMoveState(player, this, GetAnim(Anim.Move));
    AirState = new PlayerAirState(player, this, GetAnim(Anim.Air));
    SlideState = new PlayerSlideState(player, this, GetAnim(Anim.Slide));
    WallSlideState = new PlayerWallSlide(player, this, GetAnim(Anim.WallSlide));
    Attack = new AttackState(player, this, GetAnim(Anim.Attack));
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
    Player.CurrentState = currentState;
    currentState.Enter();
  }


}
