using UnityEngine;
using TMPro;

public class TranslateMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] AudioSource audioSource;
    public TextMeshProUGUI scoreText;
    private int scoreCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreCount = 0;
        scoreText.text = "Score: " + scoreCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, speed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, speed, 0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive(false);
            scoreCount = scoreCount + 1;
            scoreText.text = "Score: " + scoreCount;
            audioSource.Play();
        }
    }
}
