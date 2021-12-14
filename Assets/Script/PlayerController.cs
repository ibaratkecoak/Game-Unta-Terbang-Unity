using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float JumpPower;
    public GameObject loseScreenUI, scoreInGame;
    public int score, higScore;
    public Text scoreUI, scoreUiGame, higScoreUI;

    string HISCORE = "HISCORE";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * JumpPower;
            AudioManager.singleton.PlaySoundFX(2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        higScore = PlayerPrefs.GetInt(HISCORE);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();

    }

    void PlayerLose()
    {

        loseScreenUI.SetActive(true);
        scoreInGame.SetActive(false);
        AudioManager.singleton.PlaySoundFX(1);

        if (score > higScore)
        {
            higScore = score;
            PlayerPrefs.SetInt(HISCORE, higScore);
        }
        higScoreUI.text = higScore.ToString();
        Time.timeScale = 0;
    }

    void AddScore()
    {
        AudioManager.singleton.PlaySoundFX(0);
        score++;
        scoreUI.text = "score:  " + score.ToString();
        scoreUiGame.text = scoreUI.text;
    }
    public void RestartGame()
    {
        AudioManager.singleton.PlaySoundFX(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void mainMenuButton()
    {
        AudioManager.singleton.PlaySoundFX(3);
        SceneManager.LoadScene("menu");
        Time.timeScale = 1;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            PlayerLose();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("getpoin"))
        {
            AddScore();
        }

    }
}
