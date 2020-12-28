﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   private float speed = 3.0f;
   private Rigidbody enemyRb; 
   private GameObject player;

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
   }
}
