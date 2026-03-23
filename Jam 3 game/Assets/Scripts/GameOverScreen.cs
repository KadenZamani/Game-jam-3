using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private string gameScene;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(gameScene);
        }
    }
}
