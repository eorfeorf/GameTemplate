using System;
using Game.Scripts.Input;
using UnityEngine;
using UnityEngine.Assertions;

// TODO:ランタイムで入力タイプを切り替えられるようにする.
public class InputEventProviderFactory : MonoBehaviour
{
    [SerializeField] private bool playerKeyboardInput;

<<<<<<< HEAD
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
=======
    private IInputEventProvider inputEventProvider;
>>>>>>> 22ce05d... リファクタリング
    
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
