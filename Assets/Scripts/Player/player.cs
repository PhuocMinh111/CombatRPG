using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region  private 
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Vector2 _position;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

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
        playerStateMachine.CurrentState.Update();

    }
    public void SetVelocity(float x, float y)
    {
        _rb.velocity = new Vector2(x, y);
    }

    #region JumpForce
    public void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
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

    }
}