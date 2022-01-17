using System;
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
            try
            {
                for (;;)
                {
                    // // タイトル.
                    // var title = Instantiate(titleScenePrefab, transform) as IScene;
                    // title.Initialize();
                    // await title.IsEndAsync();
                    // title.Close();

                    // インゲーム.
                    var inGame = Instantiate(inGameScenePrefab, transform) as IScene;
                    inGame.Initialize();
                    await inGame.IsEndAsync();
                    inGame.Close();

                    // リザルト.
                    var result = Instantiate(resultScenePrefab, transform) as IScene;
                    inGame.Initialize();
                    await result.IsEndAsync();
                    result.Close();
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
                //Console.WriteLine(e);
            }
        }
    }
}