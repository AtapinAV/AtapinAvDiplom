using UnityEngine;

public class FireBallComponent : MonoBehaviour
{
    [SerializeField] private LayerMask _enemy;
    [SerializeField] private float _speedFire;
    [SerializeField] protected int _attackDamage;

    private SpriteRenderer _spriteRendererFire;
    private Rigidbody2D _rbFire;

    public SpriteRenderer SpriteRendererFire
    {
        get { return _spriteRendererFire; }
        set { _spriteRendererFire = value; }
    }
    private void Awake()
    {
        _spriteRendererFire = GetComponentInChildren<SpriteRenderer>();
        _rbFire = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveFire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f, _enemy);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<UnitsComponent>().GetDamage(_attackDamage);
        }

        Destroy(gameObject);
    }

    private void MoveFire()
    {

        if (_spriteRendererFire.flipX == false) _rbFire.velocity = Vector2.right * _speedFire;
        if (_spriteRendererFire.flipX == true) _rbFire.velocity = Vector2.left * _speedFire;
    }
}
