using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype4.Challenge4
{
   public class PlayerControllerX : MonoBehaviour
   {
      float speed = 500;
      float normalStrength = 10; // how hard to hit enemy without powerup
      float powerupStrength = 25; // how hard to hit enemy with powerup
      Rigidbody playerRb;
      GameObject focalPoint;

      [SerializeField] bool hasPowerup;
      [SerializeField] int powerUpDuration = 8;
      [SerializeField] GameObject powerupIndicator;
      [SerializeField] ParticleSystem particle;

      void Start()
      {
         playerRb = GetComponent<Rigidbody>();
         focalPoint = GameObject.Find("Focal Point");
      }

      void Update()
      {
         // Add force to player in direction of the focal point (and camera)
         float verticalInput = Input.GetAxis("Vertical");
         playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed * Time.deltaTime);

         // Set powerup indicator position to beneath player
         powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);

         if (Input.GetKey(KeyCode.Space))
         {
            speed = 1500;
         }
         else
         {
            speed = 500;
         }

         if (Input.GetKeyDown(KeyCode.Space))
         {
            particle.Play();
         }

         if (Input.GetKeyUp(KeyCode.Space))
         {
            particle.Stop();
         }
      }

      // If Player collides with powerup, activate powerup
      void OnTriggerEnter(Collider other)
      {
         if (other.gameObject.CompareTag("Powerup"))
         {
            Destroy(other.gameObject);
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCooldown());
         }
      }

      // Coroutine to count down powerup duration
      IEnumerator PowerupCooldown()
      {
         yield return new WaitForSeconds(powerUpDuration);
         hasPowerup = false;
         powerupIndicator.SetActive(false);
      }

      // If Player collides with enemy
      private void OnCollisionEnter(Collision other)
      {
         if (other.gameObject.CompareTag("Enemy"))
         {
            var enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            var awayFromPlayer = other.gameObject.transform.position - transform.position;

            if (hasPowerup) // if have powerup hit enemy with powerup force
            {
               enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            }
            else // if no powerup, hit enemy with normal strength 
            {
               enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
            }
         }
      }
   }
}