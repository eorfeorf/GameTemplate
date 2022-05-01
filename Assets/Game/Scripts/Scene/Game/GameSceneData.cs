using GameFramework.Scene;

namespace Game.Scripts.Scene.Game
{
    public sealed class GameSceneData : SceneData
    {
        public GameSceneData()
        {
            name = "Game";
            type = typeof(GameScene);
        }
    }
}
