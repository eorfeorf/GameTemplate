using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using GameFramework.Core;
using UnityEngine.SceneManagement;

namespace GameFramework.Scene
{
    /// <summary>
    /// シーンの管理
    /// </summary>
    public class GameSceneManager
    {
        private SceneData data;
        private IScene currentScene;

        private GameContext context;
        
        private readonly CancellationToken ct;
        private readonly IScreenFader fader;
        
        public GameSceneManager(CancellationToken ct, GameContext context, IScreenFader fader)
        {
            this.context = context;
            
            this.ct = ct;
            this.fader = fader;
        }
        
        public void ChangeScene(SceneData data)
        {
            LoadScene(data).Forget();
        }
    
        // Additiveを想定していない
        private async UniTask LoadScene(SceneData data)
        {
            // ロード画面ON
            await fader.FadeOut(ct);
        
            // シーンアンロード
            //await SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            
            // シーンデータを生成
            var scene = (IScene) Activator.CreateInstance(data.type);
            scene.Initialize(data, this, context);
            
            currentScene = scene;
            
            // シーンロード
            await SceneManager.LoadSceneAsync(data.name);
            
            // シーンにあるPresenterを初期化
            var goPresenter = SceneManager.GetSceneByName(data.name).GetRootGameObjects().FirstOrDefault(go => go.name == data.name);
            scene.PresenterInitialize(goPresenter);
            
        
            // ロード画面OFF
            fader.FadeIn(ct);
        }
    }
}