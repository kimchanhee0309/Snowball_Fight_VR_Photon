using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ItemSpawner : MonoBehaviourPunCallbacks
{
    public GameObject[] items; //생성할 아이템
    public Transform[] pos;

    public float timeBetSpawnMax = 4f;
    public float timeBetSpawnMin = 2f;
    private float timeBetSpawn;

    private float lastSpawnTime;

  
    void Start()
    {
        timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        lastSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
            Spawn();
        }
    }

    void Spawn()
    {
        int iitems = Random.Range(0, items.Length);
        int iPos = Random.Range(0, pos.Length);
        GameObject item = Instantiate(items[iitems], pos[iPos].position, Quaternion.identity);

        Destroy(item, 7f);
    }
}
