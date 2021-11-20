using System;
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
        [SerializeField] private InputEventProviderFactory inputPrefab;
        
        // Modules
        [SerializeField] private Module timerModule;
        [SerializeField] private Module scoreModule;
        
        public IInputEventProvider InputEventProvider { get; private set; }
        public ITimer Timer { get; private set; }
        public IScore Score { get; private set; }

        private void Awake()
        {
            InputEventProvider = Instantiate(inputPrefab, transform).InputEventProvider;
        }

        private GameObject TryCreate(Module module)
        {
            return !module.use ? null : Instantiate(module.prefab, transform);
        }
    }
}
