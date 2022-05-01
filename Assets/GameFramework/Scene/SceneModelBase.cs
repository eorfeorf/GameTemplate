using GameFramework.Core;

namespace GameFramework.Scene
{
    public class SceneModelBase<TSceneData>
    {
        public TSceneData sceneData;
        
        protected GameSceneManager gameSceneManager;
        protected GameContext gameContext;

        public void Initialize(GameSceneManager sceneManager, GameContext context)
        {
            this.gameSceneManager = gameSceneManager;
            this.gameContext = gameContext;   
        }
    }
}