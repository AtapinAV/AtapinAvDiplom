using UnityEngine;

public class HpScript : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private int _indexHP;
    [SerializeField] private AudioSource _audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioSource.Play();
        _player.Heals += _indexHP;
        Destroy(gameObject, 0.2f);
    }
}
