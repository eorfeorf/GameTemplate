using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Scene;
using UnityEngine.SceneManagement;

namespace GameFramework.Scene
{
    /// <summary>
    /// シーンの管理
    /// </summary>
    public class GameSceneManager
    {
        private SceneData data;
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
            // TODO:ロード画面ON
            fader?.FadeOut(ct);
        
            // シーンアンロード
            await SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            
            // シーンロード
            SceneManager.LoadScene(data.name);
        
            // TODO:ロード画面OFF
            fader?.FadeIn(ct);
        }
    }
}