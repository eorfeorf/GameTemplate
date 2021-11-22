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
            
            var playerView = Instantiate(playerPrefab).Setup(gameFramework.InputEventProvider);
            var playerModel = new Player.Player();
            var playerPresenter = new PlayerPresenter(playerView, playerModel);
            
            stageSequencer = new StageSequencer(playerModel);
        }
    }
}
