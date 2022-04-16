using Game.Scripts.Scene;

namespace GameFramework.Scene
{
    public interface IScene
    {
        SceneData sceneData { get; set; }

        void Initialize(SceneData sceneData);

        void OnDispose();
    }
}
