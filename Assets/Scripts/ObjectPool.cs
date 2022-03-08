using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject[] tilePrefabs;


    private Transform playerTransform;
    private float spawnZ = -6.0f;
    private float tileLength = 16.0f;
    private int amountOftiles = 7;
    private float safeZone = 15.0f;
    private List<GameObject> activeTiles;
    private int lastPrefabsIndex = 0;


    private void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i =0; i < amountOftiles; i++)
        {
            SpawnTiles();
        }
    }


    private void Update()
    {
        //for spawning tiles at the forward position
        if(playerTransform.position.z -  safeZone >  (spawnZ - amountOftiles * tileLength))
        {
            SpawnTiles();
            DeleteTiles();
        }
    }

    void SpawnTiles(int prefabIndex = -1)
    {
        GameObject gameObject;
        gameObject = Instantiate(tilePrefabs[RandomPrefabsIndex()]) as GameObject;
        gameObject.transform.SetParent(transform);

        gameObject.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;

        activeTiles.Add(gameObject);
    }

    void DeleteTiles()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabsIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabsIndex;
        while(randomIndex == lastPrefabsIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabsIndex = randomIndex;

        return randomIndex;
    }

}
