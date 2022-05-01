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
        protected GameContext context;

        public void Initialize(SceneData sceneData, GameSceneManager sceneManager, GameContext context)
        {
            model = new TModel() {sceneData = (TSceneData) sceneData};
            this.sceneManager = sceneManager;
            this.context = context;
        }

        public virtual void PresenterInitialize(GameObject go)
        {
            presenter = go.GetComponent<TPresenter>();
            presenter.Initialize(model, sceneManager, context);
        }

        public void OnDispose()
        {
        }
    }
}