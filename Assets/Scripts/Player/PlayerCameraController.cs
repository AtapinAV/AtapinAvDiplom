using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _playerDragon;
    private Vector3 _position;

    private void Update()
    {
        if (_player.gameObject.activeSelf == true && _playerDragon.gameObject.activeSelf == false)
        {
            _position = _player.position;
            _position.z = -10f;
            _position.y += 1f;
            transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime);
        }
        if (_player.gameObject.activeSelf == false && _playerDragon.gameObject.activeSelf == true)
        {
            _position = _playerDragon.position;
            _position.z = -10f;
            _position.y += 1f;
            transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime);
        }
    }
}
