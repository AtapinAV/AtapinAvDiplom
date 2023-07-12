using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _level;

    public void PlayLevelAll() => _level.SetActive(true);
    public void PlayLevel2() => SceneManager.LoadScene("GameScene2");
    public void PlayLevel() => SceneManager.LoadScene("GameScene1");
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN && !UNITY_EDITOR
            Application.Quit();
#endif
    }
}
