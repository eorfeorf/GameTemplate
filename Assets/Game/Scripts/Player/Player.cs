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

        private void Judge(Touch[] touches)
        {
            // 有効なタッチ情報をノーツに割り当てる.
            foreach (var touch in touches)
            {
                foreach (var note in notes)
                {
                    note.Judge(touch);
                }
            }
        }
    }
}