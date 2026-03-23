
using TMPro;
using UnityEngine;
public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            scoreText.text = "Zombies Slain: " + ScoreManager.Instance.score.ToString();
        }
    }
}