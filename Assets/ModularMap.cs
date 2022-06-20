using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModularMap : MonoBehaviour
{
    [SerializeField]
    GameObject startingTile, trophy;

    [SerializeField]
    int modularR = 0;

    [SerializeField]
    float s_MaxRange, s_MinRange, scaleX;
    int tilesPerR = 5;

    GameObject currentTile;
    [SerializeField]
    Transform currentTileSpawnPoint;

    [SerializeField]
    GameObject tileR, tileL;

    float counter = 0;
    bool tileType = true;
    void Start()
    {
        currentTile = startingTile;
        SpawnMap();
        SpawnTrophy();
    }

    void Update()
    {
    }

    void SpawnMap()
    {
        for(int i = 0; i < modularR; i++)
        {
            scaleX -= .5f;
            s_MinRange -= .2f;
            s_MaxRange -= .5f;
            for(int j = 0; j < tilesPerR; j++)
            {
                if (tileType)
                {
                    if (j % 2 == 0) SpawnTile(tileR, scaleX, s_MinRange, s_MaxRange);
                    else { SpawnTile(tileR, scaleX, s_MinRange, s_MaxRange / 2); }
                    counter = 0;
                    tileType = false;
                }
                else
                {
                    if (j % 2 != 0) SpawnTile(tileL, scaleX, s_MinRange, s_MaxRange);
                    else { SpawnTile(tileL, scaleX, s_MinRange, s_MaxRange / 2); }
                    counter = 0;
                    tileType = true;
                }
            }
        }
    }

    void SpawnTrophy()
    {
        Instantiate(trophy, currentTileSpawnPoint.transform.position, Quaternion.identity);
    }

    void SpawnTile(GameObject tileType, float scaleX,float minRange, float maxRange)
    {
        currentTile = Instantiate(tileType, currentTileSpawnPoint.transform.position, Quaternion.Inverse(currentTile.transform.rotation));
        currentTile.transform.localScale = new Vector3(scaleX, Random.Range(minRange, maxRange), currentTile.transform.localScale.z);
        currentTileSpawnPoint = currentTile.transform.GetChild(0).transform;
    }
}
