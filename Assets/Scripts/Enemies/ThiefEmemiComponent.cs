using UnityEngine;

public class ThiefEmemiComponent : UnitsComponent
{
    [SerializeField] private GameObject _leftEnd;
    [SerializeField] private GameObject _rightEnd;
    [SerializeField] private SpriteRenderer _spriteRendererSwordLeft;
    [SerializeField] private SpriteRenderer _spriteRendererSwordRight;
    private SpriteRenderer[] _spriteEnemy;
    private void Start()
    {
        _spriteEnemy = GetComponentsInChildren<SpriteRenderer>();
    }
    private StatesThief StateThief
    {
        set { _animator.SetInteger("StateThief", (int)value); }
    }
    private void FixedUpdate()
    {
        Movement(_leftEnd, _rightEnd);
    }

    public override void Update()
    {
        StateThief = StatesThief.walk;
        base.Update();
        Move();
        FlipDrEnemy();
        Attack();
        if (_heal <= 0) StateThief = StatesThief.die;
    }

    private void Attack()
    {
        if (_isRecharged && _dis <= _attackRange)
        {
            StateThief = StatesThief.atk;
            _isRecharged = false;
            StartCoroutine(AttackCoolDown());
        }
    }

    private void FlipDrEnemy()
    {
        if (transform.position.x < _playerUnit.transform.position.x)
        {
            foreach (SpriteRenderer render in _spriteEnemy)
            {
                render.flipX = true;
            }       
            _spriteRendererSwordRight.flipY = true;
            _spriteRendererSwordLeft.flipY = true;
            _spriteRendererSwordRight.flipX = false;
            _spriteRendererSwordLeft.flipX = false;
        }
        if (transform.position.x > _playerUnit.transform.position.x)
        {
            foreach (SpriteRenderer render in _spriteEnemy)
            {
                render.flipX = false;
            }
            _spriteRendererSwordRight.flipY = false;
            _spriteRendererSwordLeft.flipY = false;
        }
    }
}
