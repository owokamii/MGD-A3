using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Transform player;

    //coin
    public TMP_Text highCoinText;
    public TMP_Text coinText;
    int coin = 0;
    int highcoin = 0;

    //distance
    public TMP_Text highDistanceText;
    public TMP_Text distanceText;
    float highDistance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // coin
        highcoin = PlayerPrefs.GetInt("highcoin", 0);
        coinText.text = coin.ToString() + " coins";

        //distance
        highDistance = PlayerPrefs.GetFloat("highdistance", 0);
    }

    private void Update()
    {
        distanceText.text = Mathf.Round(player.position.z).ToString() + " m";
        if(highDistance < Mathf.Round(player.position.z))
        {
            PlayerPrefs.SetFloat("highdistance", Mathf.Round(player.position.z));
            //highDistanceText.text = "Longest distance ran:\n" + highDistance.ToString() + " m";
        }
    }

    public void CollectCoin()
    {
        coin += 1;
        coinText.text = coin.ToString() + " coins";
        if(highcoin < coin)
        {
            PlayerPrefs.SetInt("highcoin", coin);
        }
    }

    public void GethighScore()
    {
        highcoin = PlayerPrefs.GetInt("highcoin", 0);
        highDistance = PlayerPrefs.GetFloat("highdistance", 0);
        highCoinText.text = "Most coins collected:\n" + highcoin.ToString() + " coins";
        highDistanceText.text = "Longest distance ran:\n" + highDistance.ToString() + " m";
    }
}
