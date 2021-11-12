using System;
using Game.Scripts.Stage;
using UnityEngine;
using Game.Scripts.Player;

namespace Game.Scripts.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerView playerPrefab;
        
        private StageSequencer stageSequencer;

        private void Start()
        {
            stageSequencer = new StageSequencer();

            var playerView = Instantiate(playerPrefab);
            playerView.Setup(stageSequencer);
        }
    }
}
