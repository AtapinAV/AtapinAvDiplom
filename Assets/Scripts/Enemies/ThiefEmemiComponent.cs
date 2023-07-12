using UnityEngine;

public class ThiefEmemiComponent : UnitsComponent
{
    [SerializeField] private GameObject _leftEnd;
    [SerializeField] private GameObject _rightEnd;
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
}
