using TMPro;
using UnityEngine;

public class CoolDownManager : MonoBehaviour
{
    private bool _isCollDownRed;
    private bool _isCollDownFire;
    private bool _isCollDownDragon;

    [SerializeField] private TextMeshProUGUI _redCoolDown;
    [SerializeField] private TextMeshProUGUI _fireCoolDown;
    [SerializeField] private TextMeshProUGUI _dragonCoolDown;
    [SerializeField] private PlayerController _player;

    private TransformationComponent _transformationDragon;

    private void Awake()
    {
        _transformationDragon = GetComponent<TransformationComponent>();
    }
    private void Start()
    {
        _redCoolDown.text = _player.RedAttackCoolDownTime.ToString();
        _fireCoolDown.text = _player.FireAttackCoolDownTime.ToString();
        _dragonCoolDown.text = _transformationDragon.TransformationCoolDownTime.ToString();
    }

    private void Update()
    {
        CoolDownRed();
        CoolDownFire();
        CoolDownDragon();
    }
    private void CoolDownRed()
    {
        if (Input.GetButtonDown("Fire2My")  && _player.IsPlayAbilitiesRed) _isCollDownRed = true;
        if (_isCollDownRed && float.Parse(_redCoolDown.text) > 0f)
        {
            float a = float.Parse(_redCoolDown.text) - Time.deltaTime;
            _redCoolDown.text = a.ToString();           
            if (float.Parse(_redCoolDown.text) <= 0f)
            {
                _redCoolDown.text = _player.RedAttackCoolDownTime.ToString();
                _isCollDownRed = false;
            }            
        }       
    }
    private void CoolDownFire()
    {
        if (Input.GetButtonDown("Fire4My") && _player.IsPlayAbilitiesFire) _isCollDownFire = true;
        if (_isCollDownFire && float.Parse(_fireCoolDown.text) > 0f)
        {
            float a = float.Parse(_fireCoolDown.text) - Time.deltaTime;
            _fireCoolDown.text = a.ToString();
            if (float.Parse(_fireCoolDown.text) <= 0f)
            {
                _fireCoolDown.text = _player.FireAttackCoolDownTime.ToString();
                _isCollDownFire = false;
            }
        }
    }
    private void CoolDownDragon()
    {
        if (Input.GetButton("TransformationMy") && _player.IsPlayAbilitiesDragon) _isCollDownDragon = true;
        if (_isCollDownDragon && float.Parse(_dragonCoolDown.text) > 0f)
        {
            float a = float.Parse(_dragonCoolDown.text) - Time.deltaTime;
            _dragonCoolDown.text = a.ToString();
            if (float.Parse(_dragonCoolDown.text) <= 0f)
            {
                _dragonCoolDown.text = _transformationDragon.TransformationCoolDownTime.ToString();
                _isCollDownDragon = false;
            }
        }    
    }
}
