using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4
{
   public class RotateCamera : MonoBehaviour
   {
      [SerializeField] private float _rotationSpeed;
      [SerializeField] private GameManager _gameManager;

      // Update is called once per frame
      private void Update()
      {
         if (_gameManager?.IsGameRunning() == true)
         {
            transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime);
         }
      }
   }
}
