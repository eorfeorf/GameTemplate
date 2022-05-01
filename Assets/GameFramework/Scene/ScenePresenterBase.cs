using GameFramework.Core;
using UnityEngine;

namespace GameFramework.Scene
{
    public abstract class ScenePresenterBase<TModel> : MonoBehaviour
    {
        protected TModel model;
        protected GameSceneManager gameSceneManager;
        protected GameContext gameContext;

        public void Initialize(TModel model, GameSceneManager gameSceneManager, GameContext gameContext)
        {
            this.model = model;
            this.gameSceneManager = gameSceneManager;
            this.gameContext = gameContext;
        }

        public void SetModel(TModel model)
        {
            this.model = model;
        }
    }
}