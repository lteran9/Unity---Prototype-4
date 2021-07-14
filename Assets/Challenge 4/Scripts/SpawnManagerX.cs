using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Prototype4.Challenge4
{
   public class SpawnManagerX : MonoBehaviour
   {
      int enemyCount;
      int waveCount = 1;
      float spawnRangeX = 10;
      float spawnZMin = 15; // set min spawn Z
      float spawnZMax = 25; // set max spawn Z

      [SerializeField] GameObject player;
      [SerializeField] GameObject powerupPrefab;
      [SerializeField] GameObject[] enemies;

      void Start()
      {
         if (enemies == null) enemies = new GameObject[0];
      }

      // Update is called once per frame
      void Update()
      {
         enemyCount = FindObjectsOfType<EnemyX>().Length;

         if (enemyCount == 0)
         {
            SpawnEnemyWave(waveCount + 1);
         }
      }

      // Generate random spawn position for powerups and enemy balls
      Vector3 GenerateSpawnPosition()
      {
         float xPos = Random.Range(-spawnRangeX, spawnRangeX);
         float zPos = Random.Range(spawnZMin, spawnZMax);

         return new Vector3(xPos, 0, zPos);
      }

      void SpawnEnemyWave(int enemiesToSpawn)
      {
         var powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end
         var speedIncrease = 10 * enemiesToSpawn;

         var enemyScript = enemies.FirstOrDefault().GetComponent<EnemyX>();
         enemyScript.speed = speedIncrease;

         // If no powerups remain, spawn a powerup
         if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
         {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
         }

         // Spawn number of enemy balls based on wave number
         for (int i = 0; i < enemiesToSpawn; i++)
         {
            Instantiate(enemies[0], GenerateSpawnPosition(), enemies[0].transform.rotation);
         }

         waveCount++;

         ResetPlayerPosition(); // put player back at start
      }

      // Move player back to position in front of own goal
      void ResetPlayerPosition()
      {
         player.transform.position = new Vector3(0, 1, -7);
         player.GetComponent<Rigidbody>().velocity = Vector3.zero;
         player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
      }
   }
}