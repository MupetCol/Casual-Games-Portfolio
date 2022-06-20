using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject flower;

    private Vector3 min, max;

    private float x, y, z = 0f;
    private Vector3 randomPos;

    [SerializeField]
    private int spawnCount;


    void Start()
    {
        SetRanges();
        SpawnFlowers();
    }

    // Update is called once per frame


    private void GenerateRandomPosition()
    {
        x = UnityEngine.Random.Range(min.x, max.x);
        y = UnityEngine.Random.Range(min.y, max.y);

        randomPos = new Vector3(x, y, z);
    }

    private void SpawnFlowers()
    {
        for(int i = 0; i < spawnCount; i++)
        {
            GenerateRandomPosition();
            Instantiate(flower, randomPos, Quaternion.identity);
        }
    }

    private void SetRanges()
    {
        min = new Vector3(-25, -10, 0);
        max = new Vector3(20, 50, 0);
    }
}
