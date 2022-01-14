using UniRx;
using UnityEngine;

namespace Game.Scripts.GameContext
{
    /// <summary>
    /// ゲーム全体でまたがるデータを保持するクラス。
    /// 分割しないといけなさそう。
    /// </summary>
    public class GameContext
    {
        /// <summary>プレイ開始時間</summary>
        public IReadOnlyReactiveProperty<float> PlayStartTime => playStartTime;
        private readonly ReactiveProperty<float> playStartTime = new ReactiveProperty<float>();
        /// <summary>プレイ中時間</summary>
        public IReadOnlyReactiveProperty<float> PlayingTime => playingTime;
        private readonly ReactiveProperty<float> playingTime = new ReactiveProperty<float>();

        private float playingTimer;
        
        public void Update(float deltaTime)
        {
            // Time.deltaTimeで足すのは怖い。勇気を持って。
            playingTimer += deltaTime;
            playingTime.Value =  playingTimer - PlayStartTime.Value;
        }

        public void InGamePlay()
        {
            var time = Time.time;
            playingTimer = time;
            playStartTime.Value = time;
        }
        
    }
}
