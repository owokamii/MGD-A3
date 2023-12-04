using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float deleteSelfSec;
    void Start()
    {
        Destroy(gameObject, deleteSelfSec);
    }
}
