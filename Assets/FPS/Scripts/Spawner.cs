using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objects;                // The prefab to be spawned.
    public float spawnTime = 6f;            // How long between each spawn.
    private Vector3 spawnPosition;
    public bool stopSpawning = false;
    public int enemyNumber = 0;
    public int skor = 0;
    public int randomRx;
    public float y;
    PatrolPath pt;
    // Use this for initialization
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        
    }
    void Update()
    {
        if (enemyNumber == 1 && stopSpawning==true)
        {
            InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
    }
    void Spawn()
    {
        spawnPosition.x = Random.Range(-randomRx, randomRx);
        spawnPosition.y = y;
        spawnPosition.z = Random.Range(-randomRx, randomRx);

        Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)], spawnPosition, Quaternion.identity);
       /* foreach(var enemy in objects)
        {
            pt.enemiesToAssign.Add(enemy.gameObject);//düşmanların hareket edecekler konum için düşmanları tanımlamak
        }*/
        enemyNumber++;
        if (enemyNumber>5)
        {
            stopSpawning = true;
            CancelInvoke("Spawn");
        }
       
    }
}
