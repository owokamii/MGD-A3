using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Transform player;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    public TMP_Text coinText;

    //int score = 0;
    int highscore = 0;

    int coin = 0;
    int highcoin = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        coin = PlayerPrefs.GetInt("highcoin", 0);

        coinText.text = coin.ToString();
        //highscoreText.text = "high score: " + highscore.ToString();
    }

    private void Update()
    {
        scoreText.text = Mathf.Round(player.position.z).ToString();
    }

    /*public void Score()
    {
        score += 1;
        scoreText.text = "score: " + score.ToString();

        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }*/

    public void CollectCoin()
    {
        coin += 1;
        coinText.text = coin.ToString();
        if(highcoin < coin)
        {
            PlayerPrefs.SetInt("highcoin", coin);
        }
    }
}
