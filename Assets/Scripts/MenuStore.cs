using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuStore : MonoBehaviour
{
    [SerializeField] private PlayerController _player;
    [SerializeField] private TextMeshProUGUI _quantityAllMonet;
    [SerializeField] private TextMeshProUGUI _quantityRedMonet;
    [SerializeField] private TextMeshProUGUI _quantityFireMonet;
    [SerializeField] private TextMeshProUGUI _quantityDragonMonet;
    [SerializeField] private Button _buttonRed;
    [SerializeField] private Button _buttonFire;
    [SerializeField] private Button _buttonDragon;

    public void QuantityRed()
    {
        if (int.Parse(_quantityAllMonet.text) >= int.Parse(_quantityRedMonet.text))
        {
            int a = int.Parse(_quantityAllMonet.text) - int.Parse(_quantityRedMonet.text);
            _quantityAllMonet.text = a.ToString();
            _player.IsPlayAbilitiesRed = true;
            _buttonRed.gameObject.SetActive(false);
        }
    }
    public void QuantityFire()
    {
        if (int.Parse(_quantityAllMonet.text) >= int.Parse(_quantityFireMonet.text))
        {
            int a = int.Parse(_quantityAllMonet.text) - int.Parse(_quantityFireMonet.text);
            _quantityAllMonet.text = a.ToString();
            _player.IsPlayAbilitiesFire = true;
            _buttonFire.gameObject.SetActive(false);
        }
    }
    public void QuantityDragon()
    {
        if (int.Parse(_quantityAllMonet.text) >= int.Parse(_quantityDragonMonet.text))
        {
            int a = int.Parse(_quantityAllMonet.text) - int.Parse(_quantityDragonMonet.text);
            _quantityAllMonet.text = a.ToString();
            _player.IsPlayAbilitiesDragon = true;
            _buttonDragon.gameObject.SetActive(false);
        }
    }
}
