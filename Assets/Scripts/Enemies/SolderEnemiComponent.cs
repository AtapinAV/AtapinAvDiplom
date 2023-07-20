using UnityEngine;

public class SolderEnemiComponent : UnitsComponent
{
    [SerializeField] private GameObject _leftEnd;
    [SerializeField] private GameObject _rightEnd;
    [SerializeField] private SpriteRenderer _spriteRendererSword;
    private SpriteRenderer[] _spriteEnemy;
    private void Start()
    {
        _spriteEnemy = GetComponentsInChildren<SpriteRenderer>();
    }
    private StatesSoldier StateSoldier
    {
        set { _animator.SetInteger("StateSoldier", (int)value); }
    }
    private void FixedUpdate()
    {
        Movement(_leftEnd, _rightEnd);
    }
    public override void Update()
    {
        StateSoldier = StatesSoldier.walk;
        base.Update();
        Move();
        FlipDrEnemy();
        AttackSolder();
        if (_heal <= 0) StateSoldier = StatesSoldier.die;
    }
    private void AttackSolder()
    {
        if (_isRecharged && _dis <= _attackRange)
        {
            StateSoldier = StatesSoldier.atk;
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
            _spriteRendererSword.flipY = true;
            _spriteRendererSword.flipX = false;
        }
        if (transform.position.x > _playerUnit.transform.position.x)
        {
            foreach (SpriteRenderer render in _spriteEnemy)
            {
                render.flipX = false;
            }
            _spriteRendererSword.flipY = false;
        }
    }
}

