using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _store;

    private void Update()
    {
        PlayPause();
    }

    private void PlayPause()
    {
        if (Input.GetKey(KeyCode.Escape)) _pause.SetActive(true);
    }

    public void PlayPauseOff() => _pause.SetActive(false);
    public void PlayStore() => _store.SetActive(true);
    public void PlayStoreOff() => _store.SetActive(false);
    public void PlayMenu() => SceneManager.LoadScene("MenuScene");
}
