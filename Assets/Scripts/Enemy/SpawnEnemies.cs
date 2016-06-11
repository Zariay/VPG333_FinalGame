using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{
    public int spawnTime;
    public Transform[] groundSpawnPoints; //array of spawn points for ground enemies
    public Transform[] flyingSpawnPoints; //array of spawn points for flying enemies
    public GameObject flyingEnemy;
    public GameObject groundEnemy;

    void Start()
    {
        Invoke("Spawn", spawnTime);
    }

   void Spawn()
   {
        int groundSpawnPointIndex = Random.Range(0, groundSpawnPoints.Length);

        Instantiate(groundEnemy, groundSpawnPoints[groundSpawnPointIndex].position, groundSpawnPoints[groundSpawnPointIndex].rotation);

        int flyingSpawnPointIndex = Random.Range(0, groundSpawnPoints.Length);

        Instantiate(flyingEnemy, flyingSpawnPoints[flyingSpawnPointIndex].position, flyingSpawnPoints[flyingSpawnPointIndex].rotation);
    }
}
