using UnityEngine;

public class BlastScript : MonoBehaviour
{
    [SerializeField] private LayerMask _player;
    [SerializeField] private float _speedFire;
    [SerializeField] protected int _attackDamage;

    private SpriteRenderer _spriteRendererBlast;
    private Rigidbody2D _rbFire;

    public SpriteRenderer SpriteRendererBlast
    {
        get { return _spriteRendererBlast; }
        set { _spriteRendererBlast = value; }
    }

    private void Awake()
    {
        _spriteRendererBlast = GetComponentInChildren<SpriteRenderer>();
        _rbFire = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MoveFire();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f, _player);
        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].GetComponent<PlayerController>().GetDamagePlayers(_attackDamage);
        }

        Destroy(gameObject);
    }
    private void MoveFire()
    {
        if (_spriteRendererBlast.flipX == false) _rbFire.velocity = Vector2.right * _speedFire;
        if (_spriteRendererBlast.flipX == true) _rbFire.velocity = Vector2.left * _speedFire;
    }
}
