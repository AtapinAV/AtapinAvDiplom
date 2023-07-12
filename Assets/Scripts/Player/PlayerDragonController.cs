using System.Collections;
using UnityEngine;

public class PlayerDragonController : PlayerUnitComponents
{
    private bool _isUltRechargedDragon;
    public bool IsUltRechargedDragon
    {
        set { _isUltRechargedDragon = value; }
    }
    private bool _isFireRechargedDragon;
    public bool IsFireRechargedDragon
    {
        set { _isFireRechargedDragon = value; }
    }

    [SerializeField] private float _fireAttackCoolDownTimeDragon;
    [SerializeField] private float _ultAttackCollDownTimeDragon;
    private StatesDragon State
    {
        set { _animator.SetInteger("StateDragon", (int)value); }
    }

    public override void Awake()
    {
        base.Awake();
    }
    private void FixedUpdate()
    {
        Thereisland(1.1f);
    }

    public override void Update()
    {
        if (_canJump) State = StatesDragon.idleDragon;
        base.Update();
        if (Input.GetButtonDown("Fire1My")) FireAttack();
        if (Input.GetButtonDown("Fire2My")) UltAttack();
          
    }

    public override void Movement()
    {
        if (_canJump) State = StatesDragon.runDragon;
        base.Movement();
    }

    public override void Thereisland(float index)
    {
        base.Thereisland(index);
        if (!_canJump) State = StatesDragon.jumpDragon;
    }

    private void FireAttack()
    {
        if (_isFireRechargedDragon)
        {
            State = StatesDragon.atk1Dragon;
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

            _isFireRechargedDragon = false;

            StartCoroutine(FireAttackCoolDownDragon());
        }
    }

    private void UltAttack()
    {
        if (_isUltRechargedDragon)
        {
            State = StatesDragon.ultDragon;
            _ultSound.Play();

            if (_spriteRenderer.flipX == false) transform.position = new Vector2(transform.position.x + 5, transform.position.y);
            if (_spriteRenderer.flipX == true) transform.position = new Vector2(transform.position.x - 5, transform.position.y);

            _isUltRechargedDragon = false;

            StartCoroutine(UltAttackCoolDownDragon());
        }
    }

    private IEnumerator FireAttackCoolDownDragon()
    {
        yield return new WaitForSeconds(_fireAttackCoolDownTimeDragon);
        _isFireRechargedDragon = true;
    }

    private IEnumerator UltAttackCoolDownDragon()
    {
        yield return new WaitForSeconds(_ultAttackCollDownTimeDragon);
        _isUltRechargedDragon = true;
    }
}
