using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().PlaySFX("Coin");
            ScoreManager.instance.CollectCoin();
            this.gameObject.SetActive(false);
        }
    }
}
