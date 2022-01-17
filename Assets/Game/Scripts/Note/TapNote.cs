using System;
using Game.Scripts.Notes;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Note
{
    public class TapNote : NoteBase
    {
        private float judgeTime;

        public override void Initialize(GameContext.GameContext gameContext, NoteType noteType, float[] judgeTimes)
        {
            var judgeTime = judgeTimes[0];
            
            gameContext.PlayingTime.Subscribe(playTime =>
            {
                if (playTime >= judgeTime)
                {
                    return;
                }
                
                var pos = Vector3.zero;
                pos.z = judgeTime - gameContext.PlayingTime.Value;
                Debug.Log($"{gameContext.PlayingTime.Value}");
                transform.position = pos;
            }).AddTo(this);
        }

        public override void Judge(Touch touch, float time)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            // var pos = new pos(0f, 0f, );
            // transform.position = 
        }
    }
}