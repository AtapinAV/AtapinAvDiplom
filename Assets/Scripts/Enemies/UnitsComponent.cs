using System.Collections;
using Unity.Collections;
using UnityEngine;

public abstract class UnitsComponent : MonoBehaviour
{
    private bool _isMoving;
    protected bool _isRecharged;

    [SerializeField] private float _attackCoolDownTime;
    [SerializeField] protected PlayerUnitComponents _playerUnit;
    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected int _heal;
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected LayerMask _player;
    [SerializeField, ReadOnly] protected float _dis;
    [SerializeField] protected float _attackRange;
    [SerializeField] protected SpriteRenderer _spriteRendererUnits;
    [SerializeField] protected Transform _attackPos;
    [SerializeField] protected float _attackDis;
    [SerializeField] protected int _attackDamage;
    [SerializeField] private GameObject _prefabMonet;
    [SerializeField] private Transform _posMonet;

    protected void Awake()
    {
        _isRecharged = true;
    }

    public virtual void Update()
    {
        _dis = Vector2.Distance(_playerUnit.transform.position, transform.position);
    }    
    public void GetDamage(int damage)
    {
        StartCoroutine(EnemyDamage());
        _heal -= damage;
        if (_heal <= 0)
        {
            Destroy(gameObject, 0.8f);
            Instantiate(_prefabMonet, _posMonet.position, Quaternion.identity);
        }       
    }

    protected void Movement(GameObject _leftEndAb, GameObject _rightEndAb)
    {
        if (_dis > _attackDis)
        {
            if (_isMoving)
            {
                _rb.velocity = Vector2.right * _moveSpeed;
                if (transform.position.x > _rightEndAb.transform.position.x) _isMoving = false;
            }
            else
            {
                _rb.velocity = Vector2.left * _moveSpeed;
                if (transform.position.x < _leftEndAb.transform.position.x) _isMoving = true;
            }
        }
       
    }
    protected void Move()
    {
        if (_dis <= _attackDis)
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerUnit.transform.position, _moveSpeed * Time.deltaTime);
        }
    }
    protected void OnAttackEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPos.position, _attackRange, _player);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<PlayerController>().GetDamagePlayers(_attackDamage);      
        }
    }
    protected IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(_attackCoolDownTime);
        _isRecharged = true;
    }
    protected IEnumerator EnemyDamage()
    {
        _spriteRendererUnits.color = new Color(255f, 0f, 0f);
        yield return new WaitForSeconds(0.2f);
        _spriteRendererUnits.color = new Color(255f, 255f, 255f);
    }

#if UNITY_EDITOR
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPos.position, _attackRange);
    }
#endif
}
