using GameFramework.Core;

namespace GameFramework.Scene
{
    public abstract class ScenePresenterBase<TModel>
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
    }
}