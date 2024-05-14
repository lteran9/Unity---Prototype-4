using System;
using Prototype4.Events.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype4
{
   public class GameManager : MonoBehaviour
   {
      [SerializeField] private bool isGameRunning = false;

      [SerializeField] private GameObject _player = default;
      [SerializeField] private GameObject _spawnManager = default;

      [Header("Broadcasts on")]
      [SerializeField] private VoidEventChannelSO _endGame = default;

      [Header("Listens on")]
      [SerializeField] private VoidEventChannelSO _startGame = default;

      // Start is called before the first frame update
      private void Start()
      {

      }

      // Update is called once per frame
      private void Update()
      {
         if (IsGameRunning() && _player == null)
         {
            EndGame();
         }
      }

      private void OnEnable()
      {
         if (_startGame != null)
         {
            _startGame.OnEventRaised += StartGame;
         }
      }

      private void OnDisable()
      {
         if (_startGame != null)
         {
            _startGame.OnEventRaised -= StartGame;
         }
      }

      private void StartGame()
      {
         // Activate player and spawn manager
         _player.SetActive(true);
         _spawnManager.SetActive(true);
         // Set isGameRunning to true
         isGameRunning = true;
      }

      private void EndGame()
      {
         isGameRunning = false;
         // Send event message
         _endGame?.RaiseEvent();
      }

      public bool IsGameRunning()
      {
         return isGameRunning;
      }
   }
}