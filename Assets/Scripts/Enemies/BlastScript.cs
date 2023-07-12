using UnityEngine;

public class BlastScript : MonoBehaviour
{
    [SerializeField] private LayerMask _player;
    [SerializeField] private float _speedFire;
    [SerializeField] protected int _attackDamage;

    private Rigidbody2D _rbFire;

    private void Awake()
    {
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

        Destroy(gameObject, 0.1f);
    }
    private void MoveFire()
    {     
        _rbFire.velocity = Vector2.left * _speedFire;
    }
}
