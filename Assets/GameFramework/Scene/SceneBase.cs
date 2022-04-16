using Game.Scripts.Scene;
using GameFramework.Core;
using UnityEngine;

namespace GameFramework.Scene
{
    /// <summary>
    /// シーンの基本機能クラス.
    /// </summary>
    public abstract class SceneBase<TPresenter, TModel, TSceneData> : IScene
        where TPresenter : ScenePresenterBase<TModel>
        where TModel : SceneModelBase<TSceneData>,
        new() where TSceneData : SceneData
    {
        public SceneData sceneData { get; set; }
        protected TModel model;
        protected TPresenter presenter;

        protected GameSceneManager sceneManager;
        protected GameContext gameContext;

        public void Initialize(SceneData sceneData)
        {
            model = new TModel() {sceneData = (TSceneData) sceneData};
        }

        public virtual void InitPresenter(GameObject go)
        {
            presenter = go.GetComponent<TPresenter>();
            presenter.Initialize(model, sceneManager, gameContext);
        }

        public void OnDispose()
        {
        }
    }
}