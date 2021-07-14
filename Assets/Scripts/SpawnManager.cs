using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4
{
   public class SpawnManager : MonoBehaviour
   {
      int enemyCount;
      int waveNumber = 1;

      [SerializeField] GameObject enemyPrefab;
      [SerializeField] GameObject powerUpPrefab;

      // Start is called before the first frame update
      void Start()
      {
         SpawnEnemyWave(waveNumber);
         SpawnPowerUp();
      }

      // Update is called once per frame
      void FixedUpdate()
      {
         enemyCount = FindObjectsOfType<Enemy>().Length;

         if (enemyCount <= 0)
         {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp();
         }
      }

      void SpawnPowerUp()
      {
         Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
      }

      void SpawnEnemyWave(int enemiesToSpawn)
      {
         for (int i = 0; i < enemiesToSpawn; i++)
         {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
         }
      }

      Vector3 GenerateSpawnPosition()
      {
         float spawnPosX = Random.Range(-9, 9);
         float spawnPosY = Random.Range(-9, 9);

         return new Vector3(spawnPosX, 0.15f, spawnPosY);
      }
   }
}