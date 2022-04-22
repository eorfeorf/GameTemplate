namespace GameFramework.Scene
{
    /// <summary>
    /// シーンクラス
    /// </summary>
    public interface IScene
    {
        SceneData sceneData { get; }

        void Initialize(SceneData sceneData);

        void InitPresenter();

        void OnDispose();
    }
}
