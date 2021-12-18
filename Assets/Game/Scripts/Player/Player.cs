using System.Collections.Generic;
using Game.Scripts.MusicScore;
using Game.Scripts.Notes;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class Player
    {
        private CompositeDisposable disposable = new CompositeDisposable();
        private IInputEventProvider inputEventProvider;
        private List<NoteBase> notes;

        private float startTime; // 開始時の時間
        
        public Player(IInputEventProvider inputEventProvider, List<NoteBase> notes)
        {
            this.inputEventProvider = inputEventProvider;
            this.notes = notes;

            inputEventProvider.OnTouches.SkipLatestValueOnSubscribe().Subscribe(Judge).AddTo(disposable);
        }

        ~Player()
        {
            disposable.Dispose();
        }

        public void Play()
        {
            startTime = Time.time;
        }

        private void Judge(Touch[] touches)
        {
            var time = startTime - Time.time;
            
            // 有効なタッチ情報をノーツに割り当てる.
            foreach (var touch in touches)
            {
                foreach (var note in notes)
                {
                    note.Judge(touch, time);
                }
            }
        }
    }
}