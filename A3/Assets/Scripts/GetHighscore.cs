using UnityEngine;

public class GetHighscore : MonoBehaviour
{
    private void Start()
    {
        ScoreManager.instance.GethighScore();
    }
}
