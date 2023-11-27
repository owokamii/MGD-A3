using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.CollectCoin();
            this.gameObject.SetActive(false);
        }
    }
}
