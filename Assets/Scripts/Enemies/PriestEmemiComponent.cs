using UnityEngine;

public class PriestEmemiComponent : UnitsComponent
{
    [SerializeField] private BlastScript _prefabBlast;
    private StatesPriest StatePriest
    {
        set { _animator.SetInteger("StatePriest", (int)value); }
    }
    public override void Update()
    {
        StatePriest = StatesPriest.idle;
        base.Update();
        FireAttackEnemy();
        if (_heal <= 0) StatePriest = StatesPriest.die;
    }

    private void FireAttackEnemy()
    {
        if (_isRecharged && _dis <= _attackRange)
        {
            StatePriest = StatesPriest.atk;
            Instantiate(_prefabBlast, _attackPos.transform.position, Quaternion.identity);
            _isRecharged = false;
            StartCoroutine(AttackCoolDown());
        }
    }

}
