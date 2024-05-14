using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype4
{
   public class GameManager : MonoBehaviour
   {
      [SerializeField] private bool isGameRunning = false;

      [SerializeField] private GameObject _menu = default;
      [SerializeField] private GameObject _player = default;
      [SerializeField] private GameObject _spawnManager = default;
      [SerializeField] private GameObject _gameOverPanel = default;

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

      public void StartGame()
      {
         // Turn off menu
         _menu.SetActive(false);
         // Activate player and spawn manager
         _player.SetActive(true);
         _spawnManager.SetActive(true);
         // Set isGameRunning to true
         isGameRunning = true;
      }

      public void Settings()
      {
         Debug.Log("Settings");
      }

      public void QuitGame()
      {
#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
      }

      public void EndGame()
      {
         _gameOverPanel.SetActive(true);
         isGameRunning = false;
      }

      public void RestartGame()
      {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }

      public bool IsGameRunning()
      {
         return isGameRunning;
      }
   }
}