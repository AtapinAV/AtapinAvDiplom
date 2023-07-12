public class DragonEmemiController : UnitsComponent
{
    private StatesDrEnemy StateDrEnemy
    {
        set { _animator.SetInteger("StateDrEnemy", (int)value); }
    }

    public override void Update()
    {
        StateDrEnemy = StatesDrEnemy.idle;
        base.Update();
        Move();
        FlipDrEnemy();
        Attack();
        if (_heal <= 0) StateDrEnemy = StatesDrEnemy.die;
    }

    private void Attack()
    {
        if (_isRecharged && _dis <= _attackRange)
        {
            StateDrEnemy = StatesDrEnemy.attack;
            _isRecharged = false;
            StartCoroutine(AttackCoolDown());
        }
    }
    private void FlipDrEnemy()
    {
        if (transform.position.x < _playerUnit.transform.position.x) _spriteRendererUnits.flipX = false;
        if (transform.position.x > _playerUnit.transform.position.x) _spriteRendererUnits.flipX = true;
    }
}
