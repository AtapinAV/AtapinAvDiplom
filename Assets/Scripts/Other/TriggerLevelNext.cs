using UnityEngine;

public class TriggerLevelNext : MonoBehaviour
{
    [SerializeField] private GameObject _levelNext;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _levelNext.SetActive(true);
    }
}
