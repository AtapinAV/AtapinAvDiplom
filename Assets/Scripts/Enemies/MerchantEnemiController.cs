using System.Collections;
using UnityEngine;

public class MerchantEnemiController : UnitsComponent
{  
    private StatesMerchant StateMerchant
    {
        set { _animator.SetInteger("StateMerchant", (int)value); }
    }

    public override void Update()
    {
        StateMerchant = StatesMerchant.idle;
        base.Update();
        MoveMerchant();
        Attack();
        if (_heal <= 0) StateMerchant = StatesMerchant.die;
    }

    private void Attack()
    {
        if (_dis <= _attackRange)
        {
            StartCoroutine(DamagBomb());           
        }
    }
    private void MoveMerchant()
    {
        if (_dis <= _attackDis)
        {
            StateMerchant = StatesMerchant.walk;
            transform.position = Vector2.MoveTowards(transform.position, _playerUnit.transform.position, _moveSpeed * Time.deltaTime);
        }
    }
    private IEnumerator DamagBomb()
    {
        _spriteRendererUnits.color = new Color(0f, 0f, 0f);
        yield return new WaitForSeconds(1f);
        StateMerchant = StatesMerchant.hurt;
        Destroy(gameObject, 0.5f);
    }
}
