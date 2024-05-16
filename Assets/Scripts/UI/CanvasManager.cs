using System;
using System.Collections;
using System.Collections.Generic;
using Prototype4.Events.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

namespace Prototype4.UI {
   /// <summary>
   /// The canvas manager handles the panel views like the Menu, Settings, GameOver, etc...
   /// </summary>
   public class CanvasManager : MonoBehaviour {
      [SerializeField] private GameManager _gameManager = default;
      [SerializeField] private GameObject _menuPanel = default;
      [SerializeField] private GameObject _settingsPanel = default;
      [SerializeField] private GameObject _gameOverPanel = default;
      [SerializeField] private GameObject _gameplayPanel = default;

      [SerializeField] private TMP_Text _score = default;

      [Header("Broadcasts on")]
      [SerializeField] private VoidEventChannelSO _startGame = default;

      [Header("Listens on")]
      [SerializeField] private VoidEventChannelSO _endGame = default;

      private void OnEnable() {
         if (_endGame != null) {
            _endGame.OnEventRaised += EndGame;
         }
      }

      private void OnDisable() {
         if (_endGame != null) {
            _endGame.OnEventRaised -= EndGame;
         }
      }

      public void StartGame() {
         // Turn off menu
         _menuPanel?.SetActive(false);
         // Display gameplay panel
         _gameplayPanel?.SetActive(true);
         // Send event message
         _startGame?.RaiseEvent();
      }

      public void Settings() {
         // Turn off menu
         _menuPanel?.SetActive(false);
         // Activate settings
         _settingsPanel?.SetActive(true);
      }

      public void QuitGame() {
#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
      }

      public void Back() {
         // Activate settings
         _settingsPanel?.SetActive(false);
         // Turn off menu
         _menuPanel?.SetActive(true);
      }

      public void EndGame() {
         if (_score != null) {
            _score.text = $"Score: {_gameManager?.GetEnemyCount()}";
         }

         _gameplayPanel?.SetActive(false);
         _gameOverPanel?.SetActive(true);
      }

      public void RestartGame() {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
   }
}