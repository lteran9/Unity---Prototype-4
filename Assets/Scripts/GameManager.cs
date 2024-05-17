using System;
using Prototype4.Events.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype4 {
   public class GameManager : MonoBehaviour {
      [SerializeField] private GameObject _player = default;
      [SerializeField] private GameObject _spawnManager = default;

      [Header("Broadcasts on")]
      [SerializeField] private VoidEventChannelSO _endGame = default;

      [Header("Listens on")]
      [SerializeField] private VoidEventChannelSO _startGame = default;
      [SerializeField] private VoidEventChannelSO _enemyDestroyed = default;

      [SerializeField] private int enemyCount = 0;
      private bool isGameRunning = false, isGamePaused = false;

      // Start is called before the first frame update
      private void Start() {

      }

      // Update is called once per frame
      private void Update() {
         if (IsGameRunning()) {
            // Implement pause functionality
            if (Input.GetButtonDown("Cancel")) {
               if (isGamePaused) {
                  Time.timeScale = 1;
                  isGamePaused = false;
               } else {
                  Time.timeScale = 0;
                  isGamePaused = true;
               }
            }

            // Game over
            if (_player == null) {
               EndGame();
            }
         }
      }

      private void OnEnable() {
         if (_startGame != null) {
            _startGame.OnEventRaised += StartGame;
         }

         if (_enemyDestroyed != null) {
            _enemyDestroyed.OnEventRaised += IncreaseEnemyCount;
         }
      }

      private void OnDisable() {
         if (_startGame != null) {
            _startGame.OnEventRaised -= StartGame;
         }

         if (_enemyDestroyed != null) {
            _enemyDestroyed.OnEventRaised -= IncreaseEnemyCount;
         }
      }

      private void StartGame() {
         // Activate player and spawn manager
         _player.SetActive(true);
         _spawnManager.SetActive(true);
         // Set isGameRunning to true
         isGameRunning = true;
      }

      private void EndGame() {
         isGameRunning = false;
         // Send event message
         _endGame?.RaiseEvent();
      }

      private void IncreaseEnemyCount() {
         enemyCount++;
      }

      public bool IsGameRunning() {
         return isGameRunning;
      }

      public int GetEnemyCount() {
         return enemyCount;
      }
   }
}