using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   public int enemyCount;
   public int waveNumber = 1;

   public GameObject enemyPrefab;
   public GameObject powerUpPrefab;

   // Start is called before the first frame update
   void Start()
   {
      SpawnEnemyWave(waveNumber);
      SpawnPowerUp();
   }

   // Update is called once per frame
   void Update()
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
