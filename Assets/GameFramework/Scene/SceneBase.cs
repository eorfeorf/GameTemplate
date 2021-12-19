using System;
<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
=======
using System.Threading;
>>>>>>> 22ce05d... リファクタリング
using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// シーンの基本機能クラス.
/// </summary>
public abstract class SceneBase : MonoBehaviour, IScene
{
    [SerializeField] protected string sceneName;

<<<<<<< HEAD
    protected bool IsEnd = false;
=======
        protected bool isEnd = false;
        
        protected IScreenFader fader;
        protected CancellationToken ct;

        protected virtual void Awake()
        {
            fader = FindObjectOfType<ScreenFaderBase>();
            ct = this.GetCancellationTokenOnDestroy();
        }

        public async UniTask IsEndAsync()
        {
            await UniTask.WaitUntil(() => isEnd, cancellationToken: ct);
            Debug.Log($"SceneBase : {sceneName} -> end");
        }
>>>>>>> 22ce05d... リファクタリング

    public async UniTask IsEndAsync()
    {
        await UniTask.WaitUntil(() => IsEnd);
        Debug.Log($"SceneBase : {sceneName} -> end");
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}