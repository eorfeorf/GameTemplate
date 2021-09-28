using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// シーンの基本機能クラス.
/// </summary>
public abstract class SceneBase : MonoBehaviour, IScene
{
    [SerializeField] protected string sceneName;

    protected bool isEnd = false;

    public async UniTask IsEndAsync()
    {
        await UniTask.WaitUntil(() => isEnd);
        Debug.Log($"SceneBase : {sceneName} -> end");
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}