using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4
{
   public class RotateCamera : MonoBehaviour
   {
      [SerializeField] float rotationSpeed;

      // Update is called once per frame
      void Update()
      {
         transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
      }
   }
}
