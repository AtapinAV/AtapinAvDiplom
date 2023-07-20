using UnityEngine;

public class TriggerAb : MonoBehaviour
{
    [SerializeField] private PlayerController _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player.IsPlayAbilitiesRed = true;
        _player.IsPlayAbilitiesFire = true;
        _player.IsPlayAbilitiesDragon = true;
    }
}
