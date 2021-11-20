using System;
using UnityEngine;

public class GameFramework : MonoBehaviour
{
    // Prefabs
    [SerializeField] private ScreenFaderBase faderPrefab;
    
    public IScreenFader Fader { get; private set; }

    private void Awake()
    {
        Fader = Instantiate(faderPrefab, transform);
    }
}
