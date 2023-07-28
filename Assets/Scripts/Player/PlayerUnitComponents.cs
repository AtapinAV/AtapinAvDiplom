using UnityEngine;

public abstract class PlayerUnitComponents : MonoBehaviour
{
    protected bool _isDoubleJump;
    protected bool _canJump;
    protected bool _isPlayerControl;
    public bool IsPlayerControl { set { _isPlayerControl = value; } }

    [SerializeField] protected FireBallComponent _prefabFire;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected float _jumpForce;
    [SerializeField] protected Transform _firePos;
    [SerializeField] protected Transform _firePos2;
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected AudioSource _jumpSound;
    [SerializeField] protected AudioSource _ultSound;
    [SerializeField] protected AudioSource _fireSound;
    public virtual void Awake()
    {
        _isDoubleJump = false;
        _isPlayerControl = true;
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        if (_isPlayerControl && Input.GetButton("HorizontalMy")) Movement();
        if (_isPlayerControl && Input.GetButtonDown("JumpMy")) Jump();
    }

    public virtual void Movement()
    {
        Vector3 dir = transform.right * Input.GetAxis("HorizontalMy");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _moveSpeed * Time.deltaTime);

        _spriteRenderer.flipX = dir.x < 0f;
    }

    protected void Jump()
    {
        if (_canJump)
        {
            _jumpSound.Play();
            _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _isDoubleJump = true;
        }  
        else if (_isDoubleJump && _rb.velocity.y < 0f)
        {
            _jumpSound.Play();
            _rb.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _isDoubleJump = false;
        }
    } 

    public virtual void Thereisland(float index)
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, index);
        _canJump = collider.Length > 1;
    }  
}
