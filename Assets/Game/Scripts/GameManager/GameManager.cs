using System;
using Game.Scripts.Stage;
using UnityEngine;
using Game.Scripts.Player;

namespace Game.Scripts.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerView playerPrefab;

        private GameFramework gameFramework; 
        private StageSequencer stageSequencer;

        private void Awake()
        {
            gameFramework = FindObjectOfType<GameFramework>();
            stageSequencer = new StageSequencer();
        }

        private void Start()
        {
            var playerView = Instantiate(playerPrefab);
            playerView.Setup(stageSequencer, gameFramework.InputEventProvider);
        }
    }
}
