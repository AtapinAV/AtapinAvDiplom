using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _store;

    private bool _isPaused = false;
    private bool _isStore = false;

    private void Update()
    {
        PlayPause();
        PlayStore();
    }

    private void PlayPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    private void PlayStore()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (_isStore)
            {
                ResumeStore();
            }
            else
            {
                PauseStore();
            }
        }
    }

    public void PlayPauseOff()
    {
        _pause.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }
    public void PlayStoreOff()
    {
        _store.SetActive(false);
        Time.timeScale = 1f;
        _isStore = false;
    }
    public void PlayMenu()
    {
        SceneManager.LoadScene("MenuScene");
        _pause.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    private void Resume()
    {
        _pause.SetActive(false);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    private void Pause()
    {
        _pause.SetActive(true);
        Time.timeScale = 0f;
        _isPaused = true;
    }
    private void ResumeStore()
    {
        _store.SetActive(false);
        Time.timeScale = 1f;
        _isStore = false;
    }
    private void PauseStore()
    {
        _store.SetActive(true);
        Time.timeScale = 0f;
        _isStore = true;
    }
}
