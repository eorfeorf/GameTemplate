using GameFramework.Input;
using UniRx;
using UnityEngine;

namespace GameFramework.Core
{
    /// <summary>
    /// ゲーム全体でまたがるデータを保持するクラス。
    /// 分割しないといけなさそう。
    /// </summary>
    public class GameContext : MonoBehaviour
    {
        /// <summary>プレイ開始時間</summary>
        public IReadOnlyReactiveProperty<float> PlayStartTime => playStartTime;
        private readonly ReactiveProperty<float> playStartTime = new ReactiveProperty<float>();
        
        /// <summary>プレイ中時間</summary>
        public IReadOnlyReactiveProperty<float> PlayingTime => playingTime;
        private readonly ReactiveProperty<float> playingTime = new ReactiveProperty<float>();
        
        /// <summary>現在時間</summary>
        public IReadOnlyReactiveProperty<float> NowTime => nowTime;
        private readonly ReactiveProperty<float> nowTime = new ReactiveProperty<float>();

        /// <summary>
        /// Input
        /// </summary>
        public IInputEventProvider InputEventProvider { get; private set; }
        
        private float playingTimer;
        
        private void Update()
        {
            // Time.deltaTimeで足すのは怖い。勇気を持って。
            playingTimer += Time.deltaTime;
            playingTime.Value =  playingTimer - PlayStartTime.Value;
        }

        public void Initialize(IInputEventProvider inputEventProvider)
        {
            InputEventProvider = inputEventProvider;
        }

        public void InGamePlay()
        {
            var time = Time.time;
            playingTimer = time;
            playStartTime.Value = time;
        }
    }
}
