using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }
}
