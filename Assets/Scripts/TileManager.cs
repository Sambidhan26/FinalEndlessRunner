using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject platform;

    Vector3 lastPosition;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.z;

        //for(int i =0; i < 5; i++)
        //{
        //    SpawnZ();
        //}

        StartSpawning();
        
    }

    // Update is called once per frame
    void Update()
    {
        //StartSpawning();
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnTile", 0.1f, 0.1f);
    }

    private void SpawnTile()
    {
        int rand = Random.Range(0, 6);

        if(rand < 3)
        {
            SpawnZ();
        }

    }

    void SpawnZ()
    {
        Vector3 position = lastPosition;
        position.z += size + 9;
        //position.x = size - 50;

        lastPosition = position;

        Instantiate(platform, position, Quaternion.identity);
    }
}
