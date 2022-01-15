using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

/// <summary>
/// シーンの基本機能クラス.
/// </summary>
public abstract class SceneBase : MonoBehaviour, IScene
{
    [SerializeField] protected string sceneName;

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

    public void Close()
    {
        Destroy(gameObject);
    }
    
    public abstract void Initialize();
}