using UnityEngine;

public class FlyEnemiComponent : UnitsComponent
{
    [SerializeField] private GameObject _leftEnd;
    [SerializeField] private GameObject _rightEnd;
    [SerializeField] private BlastScript _prefabBlast;
    private void FixedUpdate()
    {
        Movement(_leftEnd, _rightEnd);
    }
    public override void Update()
    {
        base.Update();
        FireAttackEnemy();
    }

    private void FireAttackEnemy()
    {
        if (_isRecharged && _dis <= _attackRange)
        {
            Instantiate(_prefabBlast, _attackPos.transform.position, Quaternion.identity);
            _isRecharged = false;
            StartCoroutine(AttackCoolDown());
        }
    }
}
