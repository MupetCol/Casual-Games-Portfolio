using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] Fruits;

    [SerializeField]
    Transform[] SpawnPoints;

    [SerializeField]
    float t_betweenFruit = 0;
    float counter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter > t_betweenFruit)
        {
            Instantiate(Fruits[Random.Range(0, Fruits.Length)], SpawnPoints[Random.Range(0, SpawnPoints.Length)].position, Quaternion.identity);
            counter = 0;
        }

    }
}
