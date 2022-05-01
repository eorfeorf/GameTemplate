using GameFramework.Core;
using UnityEngine;

namespace GameFramework.Scene
{
    /// <summary>
    /// シーンクラス
    /// </summary>
    public interface IScene
    {
        SceneData sceneData { get; }

        void Initialize(SceneData sceneData, GameSceneManager sceneManager, GameContext context);

        void PresenterInitialize(GameObject go);

        void OnDispose();
    }
}
