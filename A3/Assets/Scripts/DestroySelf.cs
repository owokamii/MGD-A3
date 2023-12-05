using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float destroyTime;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
