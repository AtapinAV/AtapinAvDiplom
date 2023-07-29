using TMPro;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private int _indexHP;
    [SerializeField] private TextMeshProUGUI _dragonCoolDown;

    private TransformationComponent _transformationDragon;
    private CoolDownManager _coolDownManager;

    private void Awake()
    {
        _transformationDragon = GetComponent<TransformationComponent>();
        _coolDownManager = GetComponent<CoolDownManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) _player.Heals += _indexHP;
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _transformationDragon.IsTransformation = true;
            _dragonCoolDown.text = _transformationDragon.TransformationCoolDownTime.ToString();
            _coolDownManager.TimeDragonCoolDown = _transformationDragon.TransformationCoolDownTime;
            _coolDownManager.IsCoolDownDragon = false;
            _player.IsPlayAbilitiesDragon = true;
        }
    }
}
