/*using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstacles;
    public int zPos;
    public bool generating = false;
    private int obstacleType;

    private void Update()
    {
        if (!generating)
        {
            generating = true;
            StartCoroutine(GenerateObstacle());
        }
    }

    IEnumerator GenerateObstacle()
    {
        obstacleType = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[obstacleType], new Vector3(0, 5.5f, zPos), Quaternion.identity);
        zPos += 50;

        yield return new WaitForSeconds(5);
        generating = false;
    }
}
*/