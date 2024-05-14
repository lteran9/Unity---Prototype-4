using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Prototype4
{
   public class SpawnManager : MonoBehaviour
   {
      private int enemyCount;
      private int waveNumber = 1;

      [SerializeField] private GameObject _enemyPrefab;
      [SerializeField] private GameObject _powerUpPrefab;

      // Start is called before the first frame update
      private void Start()
      {
         SpawnEnemyWave(waveNumber);
         SpawnPowerUp();
      }

      // Update is called once per frame
      private void FixedUpdate()
      {
         enemyCount = FindObjectsOfType<Enemy>().Count();

         if (enemyCount <= 0)
         {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp();
         }
      }

      private void SpawnPowerUp()
      {
         Instantiate(_powerUpPrefab, GenerateSpawnPosition(), _powerUpPrefab.transform.rotation);
      }

      private void SpawnEnemyWave(int enemiesToSpawn)
      {
         for (int i = 0; i < enemiesToSpawn; i++)
         {
            Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
         }
      }

      /// <summary>
      /// Return a random position within the bounding box.
      /// </summary>
      /// <returns></returns>
      private Vector3 GenerateSpawnPosition()
      {
         // Set up the bounding box
         float spawnPosX = Random.Range(-9, 9);
         float spawnPosY = Random.Range(-9, 9);

         return new Vector3(spawnPosX, 0.15f, spawnPosY);
      }
   }
}