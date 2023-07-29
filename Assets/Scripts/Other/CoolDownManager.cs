using TMPro;
using UnityEngine;

public class CoolDownManager : MonoBehaviour
{
    private bool _isCollDownRed;
    private bool _isCollDownFire;
    private bool _isCollDownDragon;
    public bool IsCoolDownDragon
    {
        get { return _isCollDownDragon; }
        set { _isCollDownDragon = value; }
    }

    private float _timeRedCoolDown;
    private float _timeFireCoolDown;
    private float _timeDragonCoolDown;
    public float TimeDragonCoolDown
    {
        get { return _timeDragonCoolDown; }
        set { _timeDragonCoolDown = value; }
    }

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
        _timeRedCoolDown = _player.RedAttackCoolDownTime;
        _redCoolDown.text = _player.RedAttackCoolDownTime.ToString();

        _timeFireCoolDown = _player.FireAttackCoolDownTime;
        _fireCoolDown.text = _player.FireAttackCoolDownTime.ToString();

        _timeDragonCoolDown = _transformationDragon.TransformationCoolDownTime;
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
        if (_isCollDownRed && float.Parse(_redCoolDown.text) > -1f)
        {
            _timeRedCoolDown -= Time.deltaTime;
            _redCoolDown.text = Mathf.Round(_timeRedCoolDown).ToString();
            if (float.Parse(_redCoolDown.text) < 0f)
            {
                _redCoolDown.text = _player.RedAttackCoolDownTime.ToString();
                _timeRedCoolDown = _player.RedAttackCoolDownTime;
                _isCollDownRed = false;
            }
        }       
    }
    private void CoolDownFire()
    {
        if (Input.GetButtonDown("Fire4My") && _player.IsPlayAbilitiesFire) _isCollDownFire = true;
        if (_isCollDownFire && float.Parse(_fireCoolDown.text) > -1f)
        {
            _timeFireCoolDown -= Time.deltaTime;
            _fireCoolDown.text = Mathf.Round(_timeFireCoolDown).ToString();
            if (float.Parse(_fireCoolDown.text) < 0f)
            {
                _fireCoolDown.text = _player.FireAttackCoolDownTime.ToString();
                _timeFireCoolDown = _player.FireAttackCoolDownTime;
                _isCollDownFire = false;
            }
        }
    }
    private void CoolDownDragon()
    {
        if (Input.GetButton("TransformationMy") && _player.IsPlayAbilitiesDragon) _isCollDownDragon = true;
        if (_isCollDownDragon && float.Parse(_dragonCoolDown.text) > -1f)
        {
            _timeDragonCoolDown -= Time.deltaTime;
            _dragonCoolDown.text = Mathf.Round(_timeDragonCoolDown).ToString();
            if (float.Parse(_dragonCoolDown.text) < 0f)
            {
                _dragonCoolDown.text = _transformationDragon.TransformationCoolDownTime.ToString();
                _timeDragonCoolDown = _transformationDragon.TransformationCoolDownTime;
                _isCollDownDragon = false;
            }
        }    
    }
}
