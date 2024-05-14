using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4
{
   public class PlayerController : MonoBehaviour
   {
      private bool hasPowerUp;

      private float speed = 5.0f;
      private float powerUpStrength = 10.0f;

      private Rigidbody playerRb;

      [SerializeField] private GameObject focalPoint;
      [SerializeField] private GameObject powerUpIndicator;

      // Start is called before the first frame update
      private void Start()
      {
         playerRb = GetComponent<Rigidbody>();

         if (focalPoint == null)
         {
            focalPoint = GameObject.Find("Focal Point");
         }
      }

      // Update is called once per frame
      private void Update()
      {
         playerRb.AddForce(focalPoint.transform.forward * Input.GetAxis("Vertical") * speed);
         powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

         if (transform.position.y < -20)
         {
            Destroy(gameObject);
         }
      }

      private void OnTriggerEnter(Collider other)
      {
         if (other.CompareTag("PowerUp"))
         {
            hasPowerUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
         }
      }

      private void OnCollisionEnter(Collision other)
      {
         if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
         {
            var enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            var awayFromPlayer = other.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
         }
      }

      private IEnumerator PowerUpCountdownRoutine()
      {
         yield return new WaitForSeconds(7);
         hasPowerUp = false;
         powerUpIndicator.SetActive(false);
      }
   }
}