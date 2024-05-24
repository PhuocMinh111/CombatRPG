using System.Collections;
using System.Collections.Generic;
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

    #endregion

    #region property
    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }
    public float JumpForce
    {
        get { return _jumpForce; }
    }
    public bool IsGround
    {
        get { return _isGround; }
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

        playerStateMachine.CurrentState.Update();


    }
    public void SetVelocity(float x, float y)
    {
        _rb.velocity = new Vector2(x, y);
    }
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
        RaycastHit hit;
        _isGround = Physics.Raycast(transform.position, Vector3.down, out hit, 100f, LayerMask.GetMask("Ground"));
    }
}