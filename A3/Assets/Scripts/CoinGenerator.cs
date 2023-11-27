using System.Collections;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public string generatorType;

    public GameObject[] objects;
    public float delayTime;
    public int spawnDistance;
    public int spawnPos;

    public int[] coinX = { -2, 0, 2 };
    public int spawnY;

    private bool generating = false;

    private void Update()
    {
        if (!generating)
        {
            generating = true;
            StartCoroutine(GenerateObject());
        }
    }

    IEnumerator GenerateObject()
    {
        int objectType = Random.Range(0, objects.Length);

        int spawnX = Random.Range(0, 2);

        Instantiate(objects[objectType], new Vector3(coinX[spawnX], spawnY, spawnPos), Quaternion.identity);
        spawnPos += spawnDistance;

        yield return new WaitForSeconds(delayTime);
        generating = false;
    }
}
