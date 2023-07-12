using UnityEngine;

public class SolderEnemiComponent : UnitsComponent
{
    [SerializeField] private GameObject _leftEnd;
    [SerializeField] private GameObject _rightEnd;
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
}

