using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PosX", _playerPosition.position.x);
        PlayerPrefs.SetFloat("PosY", _playerPosition.position.y);
        PlayerPrefs.Save();
    }
    public void LoadPosition()
    {
        Vector2 PlayerPosition = new Vector2(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"));
        _playerPosition.position = PlayerPosition;
    }

}
