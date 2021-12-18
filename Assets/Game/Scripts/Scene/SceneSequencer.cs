using UnityEngine;

namespace Game.Scripts.Scene
{
    public sealed class SceneSequencer : MonoBehaviour
    {
        [SerializeField] private SceneBase titleScenePrefab;
        [SerializeField] private SceneBase inGameScenePrefab;
        [SerializeField] private SceneBase resultScenePrefab;

        private async void Start()
        {
            for (;;)
            {
                // タイトル.
                var title = Instantiate(titleScenePrefab, transform) as IScene;
                await title.IsEndAsync();
                title.Close();

                // インゲーム.
                var inGame = Instantiate(inGameScenePrefab, transform) as IScene;
                await inGame.IsEndAsync();
                inGame.Close();

                // リザルト.
                var result = Instantiate(resultScenePrefab, transform) as IScene;
                await result.IsEndAsync();
                result.Close();
            }
        }
    }
}