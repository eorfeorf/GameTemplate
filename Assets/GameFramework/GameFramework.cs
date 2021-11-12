using System;
using UnityEngine;

public class GameFramework : MonoBehaviour
{
    [Serializable]
    internal class Module
    {
        public bool use;
        public GameObject prefab;
    }
    
    // Prefabs
    [SerializeField] private ScreenFaderBase faderPrefab;
    [SerializeField] private InputEventProvider inputPrefab;
    
    // Modules
    [SerializeField] private Module timerModule;
    [SerializeField] private Module scoreModule;
    
    public IScreenFader Fader { get; private set; }
    public ITimer Timer { get; private set; }
    public IScore Score { get; private set; }

    private void Start()
    {
        Fader = Instantiate(faderPrefab);
        Timer = TryCreate(timerModule)?.GetComponent<ITimer>();
        Score = TryCreate(scoreModule)?.GetComponent<IScore>();
    }

    private GameObject TryCreate(Module module)
    {
        return module.use ? Instantiate(module.prefab, transform) : null;
    }
}