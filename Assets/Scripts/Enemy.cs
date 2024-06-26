﻿using System.Collections;
using System.Collections.Generic;
using Prototype4.Events.ScriptableObjects;
using UnityEngine;

namespace Prototype4 {
   public class Enemy : MonoBehaviour {
      /// <summary>
      /// Used to count score.
      /// </summary>
      [Header("Broadcasts on")]
      [SerializeField] private VoidEventChannelSO _enemyDestroyed = default;

      private int difficulty;
      private float speed = 3.0f;

      private Rigidbody enemyRb;
      private GameObject player;

      // Start is called before the first frame update
      private void Start() {
         enemyRb = GetComponent<Rigidbody>();
         player = GameObject.Find("Sphere");
      }

      // Update is called once per frame
      private void Update() {
         if (player != null) {
            // Get the Vector3 for the force direction
            var lookDirection = (player.transform.position - transform.position).normalized;
            // Add force towards player location
            enemyRb.AddForce(lookDirection * speed);
         }

         if (transform.position.y < -20) {
            if (player != null) {
               _enemyDestroyed?.RaiseEvent();
            }
            Destroy(gameObject);
         }
      }

      private float GetSpeed() {
         return speed * (1 + (difficulty * 0.1f));
      }
   }
}