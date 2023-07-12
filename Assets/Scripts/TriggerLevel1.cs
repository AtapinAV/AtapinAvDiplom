using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevel1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("GameScene2");
    }
}
