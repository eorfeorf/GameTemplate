using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO:ランタイムで入力タイプを切り替えられるようにする.
public class InputEventProviderFactory : MonoBehaviour
{
    private enum InputType
    {
        Debug,
        Release,
    }

    [SerializeField] private InputType type = InputType.Debug;

    private void Start()
    {
        switch (type)
        {
            case InputType.Debug:
                gameObject.AddComponent<DebugKeyInputEventProvider>();
                break;
            case InputType.Release:
                gameObject.AddComponent<PlayerInputEventProvider>();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
