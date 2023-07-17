using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : PlayerUnitComponents
{
    private bool _isPlayAbilitiesRed;
    public bool IsPlayAbilitiesRed
    {
        get { return _isPlayAbilitiesRed; }
        set { _isPlayAbilitiesRed = value; }
    }
    private bool _isPlayAbilitiesFire;
    public bool IsPlayAbilitiesFire
    {
        get { return _isPlayAbilitiesFire; }
        set { _isPlayAbilitiesFire = value; }
    }
    private bool _isPlayAbilitiesDragon;
    public bool IsPlayAbilitiesDragon
    {
        get { return _isPlayAbilitiesDragon; }
        set { _isPlayAbilitiesDragon = value; }
    }
    private bool _isRedRecharged;
    public bool IsRedRecharged
    {
        set { _isRedRecharged = value; }
    }

    private bool _isRecharged;
    public bool IsRecharged
    {
        set { _isRecharged = value; }
    }

    private bool _isUltRecharged;
    public bool IsUltRecharged
    {
        set { _isUltRecharged = value; }
    }

    private bool _isFireRecharged;
    public bool IsFireRecharged
    {
        set { _isFireRecharged = value; }
    }

    [SerializeField] private LayerMask _enemy;
    [SerializeField] private Transform _attackPos;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _playerControlOff;
    [SerializeField] private float _attackCoolDownTime;
    [SerializeField] private float _redAttackCoolDownTime;
    public float RedAttackCoolDownTime => _redAttackCoolDownTime;
    [SerializeField] private float _fireAttackCoolDownTime;
    public float FireAttackCoolDownTime => _fireAttackCoolDownTime;
    [SerializeField] private float _ultAttackCollDownTime;
    [SerializeField] private TextMeshProUGUI _healPlayerPro;
    [SerializeField] private int _heals;
    [SerializeField] private AudioSource _attackSound;
    [SerializeField] private AudioSource _redattackSound;
    [SerializeField] private AudioSource _damageSound;
    [SerializeField] private int _attackDamageRed;
    [SerializeField] private int _attackDamage;
    public int Heals
    {
        get { return _heals; }
        set { _heals = value; }
    }
    private States State
    {
        set { _animator.SetInteger("State", (int)value); }
    }

    public override void Awake()
    {
        base.Awake();
        _isRecharged = true;
        _isRedRecharged = true;
        _isUltRecharged = true;
        _isFireRecharged = true;
        _isPlayAbilitiesRed = false;
        _isPlayAbilitiesFire = false;
        _isPlayAbilitiesDragon = false;
    }

    private void FixedUpdate()
    {
        Thereisland(2.6f);
    }

    public override void Update()
    {
        if (_canJump) State = States.idle;
        base.Update();
        if (Input.GetButtonDown("Fire1My")) Attack();
        if (Input.GetButtonDown("Fire2My")) RedAttack();
        if (Input.GetButtonDown("Fire3My")) UltAttack();
        if (Input.GetButtonDown("Fire4My")) FireAttack();
        if (Input.GetButton("BlockMy")) Block();
        _healPlayerPro.text = _heals.ToString();
    }
    public override void Movement()
    {
        if (_canJump) State = States.run;
        base.Movement();
    }

    public override void Thereisland(float index)
    {
        base.Thereisland(index);
        if (!_canJump) State = States.jump;
    }
    private void Attack()
    {
        if (_isRecharged)
        {
            State = States.atk1;
            _attackSound.Play();
            _isRecharged = false;
            
            StartCoroutine(AttackCoolDown());
        }       
    }

    private void RedAttack()
    {
        if (_canJump && _isRedRecharged && _isPlayAbilitiesRed)
        {
            State = States.redAtk;
            
            _isRedRecharged = false;
            _isPlayerControl = false;

            StartCoroutine(PlayerControlOn());
            StartCoroutine(RedAttackCoolDown());
        }
    }

    private void UltAttack()
    {
        if (_isUltRecharged)
        {
            State = States.ult;
            _ultSound.Play();

            if (_spriteRenderer.flipX == false) transform.position = new Vector2(transform.position.x + 3, transform.position.y);
            if (_spriteRenderer.flipX == true) transform.position = new Vector2(transform.position.x - 3, transform.position.y);

            _isUltRecharged = false;

            StartCoroutine(UltAttackCoolDown());
        }
    }

    private void FireAttack()
    {
        if (_isFireRecharged && _isPlayAbilitiesFire)
        {
            State = States.skill;
            _fireSound.Play();

            if (_spriteRenderer.flipX == false)
            {
                _prefabFire.SpriteRendererFire.flipX = false;
                Instantiate(_prefabFire, _firePos.transform.position, Quaternion.identity);
            }

            if (_spriteRenderer.flipX == true)
            {
                _prefabFire.SpriteRendererFire.flipX = true;
                Instantiate(_prefabFire, _firePos2.transform.position, Quaternion.identity);
            }

            _isFireRecharged = false;

            StartCoroutine(FireAttackCoolDown());
        }
    }

    private void Block()
    {
        if (_canJump)
        {
            State = States.block;
        }
    } 
    public void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPos.position, _attackRange, _enemy);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<UnitsComponent>().GetDamage(_attackDamage);
        }
    }
    public void RedOnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPos.position, _attackRange, _enemy);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<UnitsComponent>().GetDamage(_attackDamageRed);
        }
    }
    public void GetDamagePlayers(int damage)
    {
        _damageSound.Play();
        StartCoroutine(EnemyDamage());
        _heals -= damage;
        if (_heals <= 0) SceneManager.LoadScene("MenuScene");
    }
    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(_attackCoolDownTime);
        _isRecharged = true;
    }
    private IEnumerator RedAttackCoolDown()
    {
        yield return new WaitForSeconds(_redAttackCoolDownTime);
        _isRedRecharged = true;
    }
    private IEnumerator FireAttackCoolDown()
    {
        yield return new WaitForSeconds(_fireAttackCoolDownTime);
        _isFireRecharged = true;
    }

    private IEnumerator UltAttackCoolDown()
    {
        yield return new WaitForSeconds(_ultAttackCollDownTime);
        _isUltRecharged = true;
    }

    private IEnumerator PlayerControlOn()
    {
        yield return new WaitForSeconds(_playerControlOff);
        _redattackSound.Play();
        _isPlayerControl = true;
    }
    private IEnumerator EnemyDamage()
    {
        _spriteRenderer.color = new Color(255f, 0f, 0f);
        yield return new WaitForSeconds(0.2f);
        _spriteRenderer.color = new Color(255f, 255f, 255f);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_attackPos.position, _attackRange);
    }
#endif
}
