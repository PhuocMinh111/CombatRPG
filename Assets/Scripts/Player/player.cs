using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region  private 
    [Header("movement")]
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Vector2 _position;
    [Header("Collision info")]
    [SerializeField] private float distanceToGround;
    [SerializeField] private float distanceToWall;
    [SerializeField] private LayerMask whatIsGround;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private bool _facingRight = true;
    private bool _isGround;
    private bool _airBorne;

    #endregion

    #region property
    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }
    public float xInput { get; private set; }

    public float yInput { get; private set; }
    public float DistanceToGround
    {
        get; private set;
    }
    public float JumpForce
    {
        get { return _jumpForce; }
    }
    public bool IsGround
    {
        get { return _isGround; }
    }
    public bool AirBorne
    {
        get { return _airBorne; }
    }
    public Rigidbody2D Rigidbody2D
    {
        get { return _rb; }

    }
    public SpriteRenderer SpriteRenderer
    {
        get { return _sr; }
        private set {; }
    }

    public Vector2 Position
    {
        get { return _position; }
        set { _position = value; }
    }

    #endregion

    public PlayerStateMachine playerStateMachine { get; private set; }
    public Animator PlayerAnimator { get; private set; }

    #region  MonoBehaviour
    private void Awake()
    {
        Init();
    }

    private void Start()
    {

    }


    private void Update()
    {

        CheckInput();
        CheckCollide();

        FlipController(_rb.velocity.x);
        playerStateMachine.CurrentState.Update();

    }

    private void FixedUpdate()
    {
        GroundCheck();
        Debug.Log(_isGround);
    }


    #endregion
    public void SetVelocity(float x, float y)
    {
        _rb.velocity = new Vector2(x, y);

    }

    #region Player Action
    public void Jump(float _yVelocity)
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _yVelocity * JumpForce);
    }

    public void MoveHorizontally(float _xVelocity)
    {
        _rb.velocity = new Vector2(_xVelocity * _moveSpeed, _rb.velocity.y);
    }
    public void FlipController(float _x)
    {
        if (_x > 0 && !_facingRight)
            Flip();
        else if (_x < 0 && _facingRight)
            Flip();


        void Flip()
        {
            _facingRight = !_facingRight;
            transform.Rotate(0, 180, 0);
        }
    }

    #endregion
    // init
    private void Init()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponentInChildren<Animator>();
        playerStateMachine = new PlayerStateMachine(this);

    }
    private void CheckCollide()
    {

    }
    void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log(other.gameObject.GetComponent<LayerMask>().value);
    }
    public void GroundCheck()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);
        if (hit.collider != null)
        {
            float distance = Math.Abs(hit.point.y - transform.position.y);
            // Debug.Log("distance to ground " + distance);
            _isGround = distance < distanceToGround;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - distanceToGround));
    }

}