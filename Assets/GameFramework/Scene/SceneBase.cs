using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameFramework.Scene
{
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
}