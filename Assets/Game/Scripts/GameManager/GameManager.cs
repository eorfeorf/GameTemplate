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
        [SerializeField] private ScreenFaderBase fader;
        [SerializeField] private Module timerModule;
        [SerializeField] private Module scoreModule;
        
        public IScreenFader Fader { get; private set; }
        public ITimer Timer { get; private set; }
        public IScore Score { get; private set; }

        private void Awake()
        {
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
