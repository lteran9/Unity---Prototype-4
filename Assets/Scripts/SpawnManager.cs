using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
   public GameObject enemyPrefab;

   // Start is called before the first frame update
   void Start()
   {
      Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
   }

   // Update is called once per frame
   void Update()
   {

   }

   Vector3 GenerateSpawnPosition()
   {
      float spawnPosX = Random.Range(-9, 9);
      float spawnPosY = Random.Range(-9, 9);

      return new Vector3(spawnPosX, 0.15f, spawnPosY);
   }
}
