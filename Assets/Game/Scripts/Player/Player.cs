using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Player
{
    public class Player
    {
        private CompositeDisposable disposable = new CompositeDisposable();
        private IInputEventProvider inputEventProvider;

        public Player(IInputEventProvider inputEventProvider, List<BaseNote> notes)
        {
            this.inputEventProvider = inputEventProvider;

            inputEventProvider.OnTouches.SkipLatestValueOnSubscribe().Subscribe(Judge).AddTo(disposable);
        }

        ~Player()
        {
            disposable.Dispose();
        }

        private void Judge(Touch[] touches)
        {
            // 有効なタッチ情報をノーツに割り当てる.
            
        }
    }
}