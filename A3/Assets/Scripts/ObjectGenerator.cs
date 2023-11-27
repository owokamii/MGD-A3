using System.Collections;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    /*public GameObject[] groundPrefabs;
    public float zSpawn = 0;
    public float tileLength = 20;
    public int numberOfTiles = 5;

    void Start()
    {
        for(int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile(Random.Range(0, groundPrefabs.Length));
        }
    }

    void Update()
    {
        
    }

    public void SpawnTile(int tileIndex)
    {
        Instantiate(groundPrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileIndex;
    }*/

    public string generatorType;

    public GameObject[] objects;
    public float delayTime;
    public int spawnDistance;
    public int spawnPos;

    public int minX;
    public int maxX;
    public int minY;
    public int maxY;

    private bool generating = false;

    private void Update()
    {
        if(!generating)
        {
            generating = true;
            StartCoroutine(GenerateObject());
        }
    }

    IEnumerator GenerateObject()
    {
        int objectType = Random.Range(0, objects.Length);

        int spawnX = Random.Range(minX, maxX);
        int spawnY = Random.Range(minY, maxY);

        Instantiate(objects[objectType], new Vector3(spawnX, spawnY, spawnPos), Quaternion.identity);
        spawnPos += spawnDistance;

        yield return new WaitForSeconds(delayTime);
        generating = false;
    }
}
