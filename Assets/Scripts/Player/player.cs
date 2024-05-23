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
     public PlayerState moveState {get;set;}
   public PlayerState idleState {get;set;}
    #endregion

    public PlayerStateMachine playerStateMachine {get;private set;}
    public Animator PlayerAnimator {get;private set;}
  
    private void Awake ()
    {
        _rb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponentInChildren<Animator>();
        playerStateMachine = new PlayerStateMachine();
         moveState = new PlayerState(this,playerStateMachine,"Move");
         idleState = new PlayerState(this,playerStateMachine,"Idle");
           playerStateMachine.Initialize(idleState);
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
}