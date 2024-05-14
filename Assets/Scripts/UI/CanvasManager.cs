using System.Collections;
using System.Collections.Generic;
using Prototype4.Events.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype4
{
   /// <summary>
   /// The canvas manager handles the panel views like the Menu, Settings, GameOver, etc...
   /// </summary>
   public class CanvasManager : MonoBehaviour
   {
      [SerializeField] private GameObject _menuPanel = default;
      [SerializeField] private GameObject _settingsPanel = default;
      [SerializeField] private GameObject _gameOverPanel = default;

      [Header("Broadcasts on")]
      [SerializeField] private VoidEventChannelSO _startGame = default;

      [Header("Listens on")]
      [SerializeField] private VoidEventChannelSO _endGame = default;

      private void OnEnable()
      {
         if (_endGame != null)
         {
            _endGame.OnEventRaised += EndGame;
         }
      }

      private void OnDisable()
      {
         if (_endGame != null)
         {
            _endGame.OnEventRaised -= EndGame;
         }
      }

      public void StartGame()
      {
         // Turn off menu
         _menuPanel.SetActive(false);
         // Send event message
         _startGame?.RaiseEvent();
      }

      public void Settings()
      {
         // Turn off menu
         _menuPanel.SetActive(false);
         // Activate settings
         _settingsPanel.SetActive(true);
      }

      public void QuitGame()
      {
#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
      }

      public void Back()
      {
         // Activate settings
         _settingsPanel.SetActive(false);
         // Turn off menu
         _menuPanel.SetActive(true);
      }

      public void EndGame()
      {
         _gameOverPanel.SetActive(true);
      }

      public void RestartGame()
      {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
   }
}