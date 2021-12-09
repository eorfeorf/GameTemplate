using System;
using System.Collections.Generic;
using Game.Scripts.MusicScore;
using Game.Scripts.Note;
using Game.Scripts.Notes;
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
        [SerializeField] private SceneSequencer sceneSequencerPrefab;
        [SerializeField] private InputEventProviderFactory inputPrefab;
        
        // Modules
        [SerializeField] private Module timerModule;
        [SerializeField] private Module scoreModule;
        
        public SceneSequencer SceneSequencer { get; private set; }
        public IInputEventProvider InputEventProvider { get; private set; }
        public ITimer Timer { get; private set; }
        public IScore Score { get; private set; }
        
        private void Awake()
        {
            SceneSequencer = Instantiate(sceneSequencerPrefab, transform);
            InputEventProvider = Instantiate(inputPrefab, transform).InputEventProvider;
            Timer = TryCreate(timerModule)?.GetComponent<ITimer>();
            Score = TryCreate(scoreModule)?.GetComponent<IScore>();
        }

        private GameObject TryCreate(Module module)
        {
            return module.use ? Instantiate(module.prefab, transform) : null;
        }
    }
}
