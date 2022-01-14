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
        [SerializeField] private ScreenFaderBase fadePrefab;
        
        // Core
        private SceneSequencer sceneSequencer;
        private InputEventProviderFactory input;
        private GameContext.GameContext gameContext;
        
        public SceneSequencer SceneSequencer { get; private set; }
        public IInputEventProvider InputEventProvider { get; private set; }
        public IScreenFader Fader { get; private set; }
        public GameContext.GameContext GameContext { get; private set; }
        
        
        // Modules
        [SerializeField] private Module timerModule;
        [SerializeField] private Module scoreModule;

        public ITimer Timer { get; private set; }
        public IScore Score { get; private set; }
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            
            SceneSequencer = GetComponent<SceneSequencer>();
            InputEventProvider = GetComponent<InputEventProviderFactory>().Initialize();
            Fader = Instantiate(fadePrefab, transform);
            GameContext = new GameContext.GameContext();
            
            Timer = TryCreate(timerModule)?.GetComponent<ITimer>();
            Score = TryCreate(scoreModule)?.GetComponent<IScore>();
        }

        private GameObject TryCreate(Module module)
        {
            return module.use ? Instantiate(module.prefab, transform) : null;
        }

        private void Update()
        {
            GameContext.Update(Time.deltaTime);
        }
    }
}
