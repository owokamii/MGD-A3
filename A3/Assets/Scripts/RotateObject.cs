using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateSpeed;

    private void Start()
    {
        transform.Rotate(90, 0, 0);
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
