using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   int difficulty;
   float speed = 3.0f;

   Rigidbody enemyRb;
   GameObject player;

   // Start is called before the first frame update
   void Start()
   {
      enemyRb = GetComponent<Rigidbody>();
      player = GameObject.Find("Player");
   }

   // Update is called once per frame
   void Update()
   {
      // Get the Vector3 for the force direction
      var lookDirection = (player.transform.position - transform.position).normalized;

      enemyRb.AddForce(lookDirection * speed);

      if (transform.position.y < -10)
      {
         Destroy(gameObject);
      }
   }

   float GetSpeed()
   {
      return speed * (1 + (difficulty * 0.1f));
   }
}
