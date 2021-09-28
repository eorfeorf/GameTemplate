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
        [InspectorName("timer")]
        [SerializeField] private Module timerModule;
        [InspectorName("score")]
        [SerializeField] private Module scoreModule;

        public ITimer Timer { get; private set; }
        public IScore Score { get; private set; }
        public IScreenFader Fader { get; private set; }

        private void Awake()
        {
            Timer = TryCreate(timerModule).GetComponent<ITimer>();
            Score = TryCreate(scoreModule).GetComponent<IScore>();
            Fader = FindObjectOfType<ScreenFader>();
        }

        private GameObject TryCreate(Module module)
        {
            return !module.use ? null : Instantiate(module.prefab, transform);
        }
    }
}
