using System;
using Game.Scripts.Scene;
using UnityEngine;

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
        // Core
        private SceneSequencer sceneSequencer;
        private InputEventProviderFactory input;
        private GameContext gameContext;
        
        public SceneSequencer SceneSequencer { get; private set; }
        public IInputEventProvider InputEventProvider { get; private set; }
        public GameContext GameContext { get; private set; }
        
        // Modules
        [SerializeField] private Module timerModule;
        [SerializeField] private Module scoreModule;

        public ITimer Timer { get; private set; }
        public IScore Score { get; private set; }
        
        private void Awake()
        {
            SceneSequencer = GetComponent<SceneSequencer>();
            InputEventProvider = GetComponent<InputEventProviderFactory>().Initialize();
            GameContext = GetComponent<GameContext>();
            
            Timer = TryCreate(timerModule)?.GetComponent<ITimer>();
            Score = TryCreate(scoreModule)?.GetComponent<IScore>();
        }

        private GameObject TryCreate(Module module)
        {
            return module.use ? Instantiate(module.prefab, transform) : null;
        }
    }
}
