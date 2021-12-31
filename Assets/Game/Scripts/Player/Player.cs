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
        private Rect[] touchRanges; 

        private GameManager.GameManager gameManager;

        public Player(GameManager.GameManager gameManager, List<NoteBase> notes, Rect[] touchRanges)
        {
            this.gameManager = gameManager;
            this.notes = notes;
            this.touchRanges = touchRanges;

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
            // 判定をとるノーツを調べる（タッチタイミングで有効な時間の時だけ反応する）
            
            // 有効なタッチ情報をノーツに割り当てる.
            foreach (var touch in touches)
            {
                // タッチ範囲にタッチしたらノーツを押したことにする
                var touchPos = touch.position;

                foreach (var note in notes)
                {
                    note.Judge(touch, gameManager.GameContext.PlayingTime.Value);
                }
            }
        }

        private bool AABB2D(Rect range, Vector2 pos)
        {
            var rangeX = range.xMin + range.width;
            var rangeY = range.yMax + range.height;

            return range.xMin <= pos.x && pos.x <= rangeX &&
                   range.yMin <= pos.y && pos.y <= rangeY;
        }
    }
}