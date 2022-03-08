using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    //public Transform platform1;
    //public GameObject platform2;
    //public GameObject platform3;
    //public GameObject platform4;

    public GameObject blockPrefabs;

    public Transform spawnRandom1;
    public Transform spawnRandom2;

    float timeInterval;
    float timeInterval2;
    //public Transform spawnRandom2;
    //public Transform spawnRandom2;
    // Start is called before the first frame update
    void Start()
    {
        timeInterval = Random.Range(2.0f, 15.0f);
        timeInterval2 = Random.Range(3.0f, 12.0f);

        InvokeRepeating("SpawnPoint", timeInterval, timeInterval);
        InvokeRepeating("SpawnPoint2", timeInterval2, timeInterval2);
        //InvokeRepeating("SpawnPointHello", 10.0f, 15.0f);
        //InvokeRepeating("SpawnPoint1", 0.5f, 1.0f);
        //InvokeRepeating("SpawnPoint2", 1.0f, 1.0f);\
        
    }

    // Update is called once per frame
    void Update()
    {


        //InvokeRepeating("SpawnPoint", 0.5f, 1.0f);
        //InvokeRepeating("SpawnPoint2", 1.0f, 1.0f);

        //StartCoroutine("SpawnPoint1");
        //StartCoroutine("SpawnPoint2");
        //int spawn = Random.Range(0, spawnRandom.Length);
        //Instantiate(blockPrefabs,new Vector3(spawnRandom[spawn].position.x,spawn + 1.0f,spawnRandom[spawn].position.z), Quaternion.identity);
        //Instantiate(blockPrefabs, spawnRandom2.position, Quaternion.identity);
    }

    //IEnumerator SpawnPoint1()
    //{
    //    Instantiate(blockPrefabs, spawnRandom1.position, Quaternion.identity);
    //    yield return new WaitForSeconds(0.1f);
    //}

    //IEnumerator SpawnPoint2()
    //{
    //    Instantiate(blockPrefabs, spawnRandom2.position, Quaternion.identity);
    //    yield return new WaitForSeconds(0.1f);
    //}

    void SpawnPoint()
    {
        Instantiate(blockPrefabs, spawnRandom1.position, Quaternion.identity);
    }

    void SpawnPoint2()
    {
        Instantiate(blockPrefabs, spawnRandom2.position, Quaternion.identity);
    }
    //void SpawnPointHello()
    //{
    //    Instantiate(blockPrefabs, spawnRandom2.position, Quaternion.identity);
    //}
}
