using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   bool hasPowerUp;

   float speed = 5.0f;
   float powerUpStrength = 10.0f;

   Rigidbody playerRb;
   GameObject focalPoint;

   [SerializeField] GameObject powerUpIndicator;

   // Start is called before the first frame update
   void Start()
   {
      playerRb = GetComponent<Rigidbody>();
      focalPoint = GameObject.Find("Focal Point");
   }

   // Update is called once per frame
   void Update()
   {
      playerRb.AddForce(focalPoint.transform.forward * Input.GetAxis("Vertical") * speed);
      powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

      if (transform.position.y < -10)
      {
         Destroy(gameObject);
      }
   }

   void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("PowerUp"))
      {
         hasPowerUp = true;
         powerUpIndicator.SetActive(true);
         Destroy(other.gameObject);
         StartCoroutine(PowerUpCountdownRoutine());
      }
   }

   void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
      {
         var enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
         var awayFromPlayer = other.gameObject.transform.position - transform.position;

         enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
      }
   }

   IEnumerator PowerUpCountdownRoutine()
   {
      yield return new WaitForSeconds(7);
      hasPowerUp = false;
      powerUpIndicator.SetActive(false);
   }
}
