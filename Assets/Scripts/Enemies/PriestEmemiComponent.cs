using UnityEngine;

public class PriestEmemiComponent : UnitsComponent
{
    [SerializeField] private BlastScript _prefabBlast;
    [SerializeField] private Transform _attackPos2;
    private StatesPriest StatePriest
    {
        set { _animator.SetInteger("StatePriest", (int)value); }
    }
    private SpriteRenderer[] _spriteEnemy;
    private void Start()
    {
        _spriteEnemy = GetComponentsInChildren<SpriteRenderer>();
    }
    public override void Update()
    {
        StatePriest = StatesPriest.idle;
        base.Update();
        FlipDrEnemy();
        FireAttackEnemy();
        if (_heal <= 0) StatePriest = StatesPriest.die;
    }

    private void FireAttackEnemy()
    {
        if (_isRecharged && _dis <= _attackRange)
        {
            StatePriest = StatesPriest.atk;

            if (_spriteRendererUnits.flipX == false)
            {
                _prefabBlast.SpriteRendererBlast.flipX = true;
                Instantiate(_prefabBlast, _attackPos.transform.position, Quaternion.identity);
            }
            if (_spriteRendererUnits.flipX == true)
            {
                _prefabBlast.SpriteRendererBlast.flipX = false;
                Instantiate(_prefabBlast, _attackPos2.transform.position, Quaternion.identity);
            }
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
        }
        if (transform.position.x > _playerUnit.transform.position.x)
        {
            foreach (SpriteRenderer render in _spriteEnemy)
            {
                render.flipX = false;
            }
        }
    }
}
