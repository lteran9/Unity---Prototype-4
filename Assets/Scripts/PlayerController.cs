using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float speed = 5.0f;

   private Rigidbody playerRb;

   // Start is called before the first frame update
   void Start()
   {
      playerRb = GetComponent<Rigidbody>();
   }

   // Update is called once per frame
   void Update()
   {
      float verticalInput = Input.GetAxis("Vertical");

      playerRb.AddForce(Vector3.forward * verticalInput * speed);
   }
}
