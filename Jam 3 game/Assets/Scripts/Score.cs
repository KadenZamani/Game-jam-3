using UnityEngine;
using TMPro; 
public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public static ScoreManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
        
    }
    public int GetScore()
    {
        return score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
    public void Update()
    {
        {

        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Zombies Slain: " + score;
    }
}