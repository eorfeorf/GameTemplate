using System;
using Game.Scripts.Input;
using UnityEngine;
using UnityEngine.Assertions;

// TODO:ランタイムで入力タイプを切り替えられるようにする.
public class InputEventProviderFactory : MonoBehaviour
{
    [SerializeField] private bool playerKeyboardInput;

    public IInputEventProvider InputEventProvider;

    public IInputEventProvider Initialize()
    {
        if (playerKeyboardInput)
        {
            InputEventProvider = gameObject.AddComponent<PlayerInputEventProvider>();   
        }
        
#if UNITY_EDITOR
        InputEventProvider = gameObject.AddComponent<DebugKeyInputEventProvider>();
#endif
        
        Assert.IsNotNull(InputEventProvider);
        return InputEventProvider;
    }
    
    private void Awake()
    {
        if (playerKeyboardInput)
        {
            InputEventProvider = gameObject.AddComponent<PlayerInputEventProvider>();   
        }
        
#if UNITY_EDITOR
        InputEventProvider = gameObject.AddComponent<DebugKeyInputEventProvider>();
#endif
        
        Assert.IsNotNull(InputEventProvider);
    }
}
