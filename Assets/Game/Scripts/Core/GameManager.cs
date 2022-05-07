using Cysharp.Threading.Tasks;
using Game.Scripts.Input;
using GameFramework.Core;
using GameFramework.Fader;
using GameFramework.Input;
using GameFramework.Scene;
using UnityEngine;

namespace Game.Scripts.Core
{
    /// <summary>
    /// 最初にオブジェクトを生成する起点となるクラス
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        // TODO:別クラスで設定する.SceneManagerに直接渡す.
        [SerializeField] private ScreenFaderBase fadePrefab;
        
        public GameSceneManager GameSceneManager { get; private set; }
        public GameContext GameContext => gameContext;
        public IInputEventProvider InputEventProvider { get; private set; }
        public IScreenFader Fader { get; private set; }

        private GameSceneManager gameSceneManager;
        private InputEventProviderFactory input;
        private GameContext gameContext;
        
        private void Awake()
        {
            var ct = this.GetCancellationTokenOnDestroy();
            
            // Create Modules. 
            InputEventProvider = GetComponent<InputEventProviderFactory>().Initialize();
            Fader = Instantiate(fadePrefab, null);
            
            // Context
            gameContext = GetComponent<GameContext>();
            gameContext.Initialize(InputEventProvider);
            
            // SceneManager
            GameSceneManager = new GameSceneManager(ct, gameContext, Fader);
            
            DontDestroyOnLoad(gameObject);
        }
    }
}
