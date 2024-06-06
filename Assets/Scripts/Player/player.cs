using System;

using UnityEngine;

public class Player : MonoBehaviour
{

    #region  private 
    [Header("movement")]
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _dashSpeed = 8f;
    [SerializeField] private float _slideSpeed = 12f;
    [SerializeField] private float _slideDuration = .8f;
    [SerializeField] private Vector2 _position;
    [Header("Collision info")]
    [SerializeField] private float distanceToGround;
    [SerializeField] private float distanceToWall;
    [SerializeField] private float playerHeight;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D _rb;

    private SpriteRenderer _sr;
    private bool _facingRight = true;
    private bool _isGround;
    private bool _airBorne;
    private bool _isSliding = false;
    private Timer slideTimer;

    #endregion

    #region property
    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }
    public float SlideSpeed
    {
        get { return _slideSpeed; }
    }
    public float DashSpeed
    {
        get { return _dashSpeed; }
    }
    public int PlayerLayer { get; private set; }
    public int EnemyLayer { get; private set; }
    public Timer SlideTimer
    {
        get { return slideTimer; }
    }
    public float SlideDuration
    {
        get { return _slideDuration; }
    }
    public float FacingDir { get; set; } = 1;

    public bool IsSliding
    {
        get { return _isSliding; }
    }
    public bool IsHitWall { get; private set; }

    public bool FacingRight
    {
        get { return _facingRight; }
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
    public bool IsGround { get; private set; }
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
    private void Init()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponentInChildren<Animator>();
        playerStateMachine = new PlayerStateMachine(this);
        PlayerLayer = LayerMask.NameToLayer("Player");
        EnemyLayer = LayerMask.NameToLayer("Enemy");

    }
    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        slideTimer = gameObject.AddComponent<Timer>();
    }


    private void Update()
    {

        CheckInput();


        FlipController(_rb.velocity.x);
        playerStateMachine.CurrentState.Update();

    }

    private void FixedUpdate()
    {
        CheckCollide();

    }


    #endregion
    public void SetVelocity(float x, float y)
    {
        _rb.velocity = new Vector2(x, y);

    }




    #region Player Action

    public void MoveHorizontally(float _xMultiply)
    {
        var xClamp = Math.Clamp(_xMultiply, -3, 3);

        _rb.velocity = new Vector2(xClamp * _moveSpeed, _rb.velocity.y);
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
            FacingDir = _facingRight ? 1 : -1;
            transform.Rotate(0, 180, 0);
        }
    }

    #endregion
    // init

    #region  Input Action

    protected void SetVelocity()
    {
        _rb.velocity = new Vector2(xInput * MoveSpeed, yInput * JumpForce);
    }

    void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }



    #endregion






    #region check collide
    private void CheckCollide()
    {
        GroundCheck();
        WallCheck();
        Debug.Log("is hit wall " + IsHitWall);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log(other.gameObject.GetComponent<LayerMask>().value);
    }
    private void WallCheck()
    {
        Collider2D hit = Physics2D.OverlapBox(new Vector2(transform.position.x + distanceToWall * FacingDir, transform.position.y), new Vector2(.1f, playerHeight), EnemyLayer);
        if (hit != null)
        {
            // float distance = Math.Abs(hit - transform.position.y);
            if (hit.gameObject.tag == "Flatform")
            {

                IsHitWall = true;
            }
            else
            {
                IsHitWall = false;
            }
        }

    }
    private void GroundCheck()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);
        if (hit.collider != null)
        {
            float distance = Math.Abs(hit.point.y - transform.position.y);
            // Debug.Log("distance to ground " + distance);
            IsGround = distance <= distanceToGround;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - distanceToGround));
        Gizmos.DrawWireCube(new Vector2(transform.position.x + distanceToWall * FacingDir, transform.position.y), new Vector2(.1f, playerHeight));

    }
    #endregion

}