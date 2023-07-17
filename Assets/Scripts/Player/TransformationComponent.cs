using System.Collections;
using UnityEngine;

public class TransformationComponent : MonoBehaviour
{
    private bool _isTransformation;

    [SerializeField] PlayerController _player;
    [SerializeField] PlayerDragonController _playerDragon;
    [SerializeField] private float _transformationTime;
    [SerializeField] private float _transformationCoolDownTime;
    public float TransformationCoolDownTime => _transformationCoolDownTime;

    private void Start()
    {
        _isTransformation = true;
    }

    private void Update()
    {
        if (Input.GetButton("TransformationMy")) Transformation();
    }

    private void Transformation()
    {
        if (_isTransformation && _player.IsPlayAbilitiesDragon)
        {
            _playerDragon.gameObject.SetActive(true);
            _player.gameObject.SetActive(false);
            _playerDragon.transform.position = _player.transform.position;
            _playerDragon.IsUltRechargedDragon = true;
            _playerDragon.IsFireRechargedDragon = true;
            _isTransformation = false;

            StartCoroutine(TransformationCoolDown());
            StartCoroutine(TransformationTime());
        }
    }
    private IEnumerator TransformationTime()
    {
        yield return new WaitForSeconds(_transformationTime);
        _playerDragon.gameObject.SetActive(false);
        _player.gameObject.SetActive(true);
        _player.transform.position = _playerDragon.transform.position;
        _player.IsRecharged = true;
        _player.IsRedRecharged = true;
        _player.IsFireRecharged = true;
        _player.IsUltRecharged = true;
        _player.IsPlayerControl = true;
    }

    private IEnumerator TransformationCoolDown()
    {
        yield return new WaitForSeconds(_transformationCoolDownTime);
        _isTransformation = true;
    }
}
