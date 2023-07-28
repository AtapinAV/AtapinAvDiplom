using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevelNext : MonoBehaviour
{
    public void PlayLevel2() => SceneManager.LoadScene("GameScene2");
    public void PlayLevel() => SceneManager.LoadScene("GameScene1");
    public void PlayMenu() => SceneManager.LoadScene("MenuScene");
}
