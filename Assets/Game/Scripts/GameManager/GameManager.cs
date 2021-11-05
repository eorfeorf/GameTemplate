using System;
using Game.Scripts.Stage;
using UnityEngine;
using Game.Scripts.Player;

namespace Game.Scripts.GameManager
{
    [Serializable]
    internal class Module
    {
        public bool use;
        public GameObject prefab;
    }
    
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ScreenFaderBase fader;
        [SerializeField] private Module timerModule;
        [SerializeField] private Module scoreModule;
        
        public IScreenFader Fader { get; private set; }
        public ITimer Timer { get; private set; }
        public IScore Score { get; private set; }

        public StageSequencer StageSequencer;

        private Player.Player player;

        private void Start()
        {
            StageSequencer = new StageSequencer();

            //player = GameObject.FindObjectOfType<Player.Player>();
            player.Setup(StageSequencer);
            
            Fader = Instantiate(fader);
            Timer = TryCreate(timerModule)?.GetComponent<ITimer>();
            Score = TryCreate(scoreModule)?.GetComponent<IScore>();
        }

        private GameObject TryCreate(Module module)
        {
            return !module.use ? null : Instantiate(module.prefab, transform);
        }
    }
}
