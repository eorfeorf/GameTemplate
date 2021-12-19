using System;
using Game.Scripts.Input;
using UnityEngine;
using UnityEngine.Assertions;

// TODO:ランタイムで入力タイプを切り替えられるようにする.
public class InputEventProviderFactory : MonoBehaviour
{
    [SerializeField] private bool playerKeyboardInput;

    private IInputEventProvider inputEventProvider;
    
    public IInputEventProvider Initialize()
    {
        if (playerKeyboardInput)
        {
            inputEventProvider = gameObject.AddComponent<PlayerInputEventProvider>();   
        }
        
#if UNITY_EDITOR
        inputEventProvider = gameObject.AddComponent<DebugKeyInputEventProvider>();
#endif
        
        Assert.IsNotNull(inputEventProvider);

        return inputEventProvider;
    }
}
