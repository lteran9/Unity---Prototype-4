using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public bool hasPowerUp;

   public float speed = 5.0f;
   public float powerUpStrength = 10.0f;
   
   public GameObject powerUpIndicator;
   private GameObject focalPoint;
   private Rigidbody playerRb;

   // Start is called before the first frame update
   void Start()
   {
      playerRb = GetComponent<Rigidbody>();
      focalPoint = GameObject.Find("Focal Point");
   }

   // Update is called once per frame
   void Update()
   {
      float verticalInput = Input.GetAxis("Vertical");

      playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);

      powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
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
