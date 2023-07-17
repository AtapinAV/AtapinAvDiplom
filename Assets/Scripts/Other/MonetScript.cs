using TMPro;
using UnityEngine;

public class MonetScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _monet;
    [SerializeField] private int _indexMN;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _audioSource.Play();
        int a = int.Parse(_monet.text) + _indexMN;
        _monet.text = a.ToString();
        Destroy(gameObject, 0.2f);
    }
}

