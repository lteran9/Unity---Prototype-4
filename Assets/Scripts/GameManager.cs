using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype4
{
   public class GameManager : MonoBehaviour
   {
      private bool isGameRunning = false;

      [SerializeField] private GameObject _menu = default;
      [SerializeField] private GameObject _player = default;
      [SerializeField] private GameObject _spawnManager = default;
      [SerializeField] private GameObject _gameOverPanel = default;

      // Start is called before the first frame update
      private void Start()
      {
         isGameRunning = true;
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
         Debug.Log("Start Game");
         _menu.SetActive(false);
         _player.SetActive(true);
         _spawnManager.SetActive(true);
      }

      public void Settings()
      {
         Debug.Log("Settings");
      }

      public void QuitGame()
      {
         Debug.Log("Quit Game");
      }

      public void EndGame()
      {
         isGameRunning = false;
         _gameOverPanel.SetActive(true);
      }

      public bool IsGameRunning()
      {
         return isGameRunning;
      }
   }
}