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
        private List<NoteBase> notes;

        private GameManager.GameManager gameManager;

        public Player(GameManager.GameManager gameManager, List<NoteBase> notes)
        {
            this.gameManager = gameManager;
            this.notes = notes;

            gameManager.InputEventProvider.OnTouches.SkipLatestValueOnSubscribe().Subscribe(Judge).AddTo(disposable);
        }

        ~Player()
        {
            disposable.Dispose();
        }

        public void Play()
        {
            gameManager.GameContext.InGamePlay();
        }

        private void Judge(Touch[] touches)
        {
            // 有効なタッチ情報をノーツに割り当てる.
            foreach (var touch in touches)
            {
                foreach (var note in notes)
                {
                    note.Judge(touch, gameManager.GameContext.PlayingTime.Value);
                }
            }
        }
    }
}