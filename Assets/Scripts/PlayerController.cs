using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverScore;
    public TextMeshProUGUI highScoreText;
    public bool isGameActive = true;

    private const float jumpForce = 18.0f;
    private const float yMax = 5.0f;

    private Rigidbody rb;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameOverPanel.SetActive(false);
        SetHighScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

            if (transform.position.y > yMax)
            {
                transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
                rb.velocity = Vector3.zero;
            }
            else if (transform.position.y < -7)
            {
                GameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Opening"))
        {
            score++;
            scoreText.text = "Score: " + score;
        }
        else if (other.CompareTag("Wall"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameActive = false;
        gameOverScore.text = "Score: " + score;
        gameOverPanel.SetActive(true);

        if (score > GameManager.Instance.HighScore)
        {
            GameManager.Instance.HighScore = score;
            GameManager.Instance.SaveDatabase();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void SetHighScoreText()
    {
        highScoreText.text = "High Score: " + GameManager.Instance.HighScore;
    }
}
