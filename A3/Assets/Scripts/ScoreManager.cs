using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Transform player;

    //coin
    public TMP_Text coinText;
    public TMP_Text highCoinText;
    int coin = 0;
    int highCoin = 0;

    //distance
    public TMP_Text distanceText;
    public TMP_Text highDistanceText;
    float highDistance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // coin
        highCoin = PlayerPrefs.GetInt("highcoin", 0);
        coinText.text = coin.ToString() + " coins";
        highCoinText.text = "Highest amount of coins collected:\n" + highCoin.ToString() + " coins";

        //distance
        highDistance = PlayerPrefs.GetFloat("highdistance", 0);
        highDistanceText.text = "Longest distance ran:\n" + highDistance.ToString() + " m";
    }

    private void Update()
    {
        distanceText.text = Mathf.Round(player.position.z).ToString() + " m";
        if(highDistance < Mathf.Round(player.position.z))
        {
            PlayerPrefs.SetFloat("highdistance", Mathf.Round(player.position.z));
            highDistanceText.text = "Longest distance ran:\n" + highDistance.ToString() + " m";
        }
    }

    public void CollectCoin()
    {
        coin += 1;
        coinText.text = coin.ToString() + " coins";
        if(highCoin < coin)
        {
            PlayerPrefs.SetInt("highcoin", coin);
            highCoinText.text = "Highest amount of coins collected:\n" + highCoin.ToString() + " coins";
        }
    }

    public void GethighScore()
    {
        highCoin = PlayerPrefs.GetInt("highcoin", 0);
        highDistance = PlayerPrefs.GetFloat("highdistance", 0);
    }
}
