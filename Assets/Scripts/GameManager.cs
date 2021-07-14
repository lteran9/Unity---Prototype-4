using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Prototype4
{
   public class GameManager : MonoBehaviour
   {
      bool isGameRunning = false;

      [SerializeField] GameObject _menu = default;
      [SerializeField] GameObject _player = default;
      [SerializeField] GameObject _spawnManager = default;
      [SerializeField] GameObject _gameOverPanel = default;

      // Start is called before the first frame update
      void Start()
      {
         isGameRunning = true;
      }

      // Update is called once per frame
      void Update()
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