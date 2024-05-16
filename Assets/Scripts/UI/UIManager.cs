using System.Collections;
using System.Collections.Generic;
using Prototype4.Events.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Prototype4.UI {
   public class UIManager : MonoBehaviour {
      [SerializeField] private TMP_Text _waveCount = default;
      /// <summary>
      /// Called every time a wave is spawned.
      /// </summary>
      [Header("Listens on")]
      [SerializeField] private VoidEventChannelSO _newWaveSpawned = default;

      private void OnEnable() {
         if (_newWaveSpawned != null) {
            _newWaveSpawned.OnEventRaised += UpdateWaveUI;
         }
      }

      private void OnDisable() {
         if (_newWaveSpawned != null) {
            _newWaveSpawned.OnEventRaised -= UpdateWaveUI;
         }
      }

      private void UpdateWaveUI() {
         int.TryParse(_waveCount.text, out int count);
         count++;
         if (count > 0) {
            _waveCount.text = count.ToString();
         }
      }
   }
}