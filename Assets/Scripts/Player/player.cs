using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    #region  private 
          [SerializeField] private float _moveSpeed = 3f;
          [SerializeField] private Vector2 _position;
    private Rigidbody2D _rb ;

    #endregion

    #region property
      public float MoveSpeed 
      {
        get {return _moveSpeed;}
      }
      public Rigidbody2D Rigidbody2D 
        {
        get {return _rb;} 
      
        }
    public Vector2 Position
    {
        get {return _position;}
        set {_position = value;}
    }
    public PlayerState MoveState {get;set;}
    public PlayerState IdleState {get;set;}
    #endregion

    public PlayerStateMachine playerStateMachine {get;private set;}
    public Animator PlayerAnimator {get;private set;}
  
    private void Awake ()
    {
       Init();
    }

    private void Start()
    {
     
    }


    private void Update()
    {
      
        playerStateMachine.currentState.Update();
        
      
    }
    public void SetVelocity (float x,float y) 
    {
        _rb.velocity = new Vector2(x,y);
    }
    // init
    private void Init()
    {
         _rb = GetComponent<Rigidbody2D>();
          PlayerAnimator = GetComponentInChildren<Animator>();
         playerStateMachine = new PlayerStateMachine();
         MoveState = new PlayerMoveState(this,playerStateMachine,"Move");
         IdleState = new PlayerIdleState(this,playerStateMachine,"Idle");
            playerStateMachine.Initialize(IdleState);
    }
}