﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4.Challenge4
{
   public class RotateCameraX : MonoBehaviour
   {
      float speed = 200;

      [SerializeField] GameObject player;

      // Update is called once per frame
      void Update()
      {
         float horizontalInput = Input.GetAxis("Horizontal");
         transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

         transform.position = player.transform.position; // Move focal point with player

      }
   }
}