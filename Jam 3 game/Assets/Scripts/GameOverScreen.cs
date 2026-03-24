using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private string gameScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(gameScene);
            ScoreManager.Instance.score = 0;
            Destroy(ScoreManager.Instance.gameObject);
        }
    }
}
