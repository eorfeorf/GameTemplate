using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
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
        
        private readonly CancellationToken ct;
        private readonly IScreenFader? fader;
        
        public GameSceneManager(CancellationToken ct, IScreenFader fader)
        {
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
            fader?.FadeOut(ct);
        
            // シーンアンロード
            await SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            
            // シーンを生成
            var scene = (IScene) Activator.CreateInstance(data.type);
            scene.Initialize(data);
            scene.InitPresenter();
            
            
            currentScene = scene;
            
            // シーンロード
            await SceneManager.LoadSceneAsync(data.name);
            
            // シーンにあるPresenterを初期化
            // var goPresenter = SceneManager.GetSceneByName(data.name).GetRootGameObjects().FirstOrDefault(go => go.name == data.name);
            // goPresenter
            
        
            // ロード画面OFF
            fader?.FadeIn(ct);
        }
    }
}