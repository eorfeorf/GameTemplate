using System;
using UnityEngine;

// TODO:ランタイムで入力タイプを切り替えられるようにする.
public class InputEventProvider : MonoBehaviour
{
    [SerializeField] private bool playerKeyboardInput;
    
    private void Start()
    {
#if UNITY_EDITOR
        gameObject.AddComponent<DebugKeyInputEventProvider>();
#endif
        
        if (playerKeyboardInput)
        {
            gameObject.AddComponent<PlayerInputEventProvider>();   
        }
    }
}
