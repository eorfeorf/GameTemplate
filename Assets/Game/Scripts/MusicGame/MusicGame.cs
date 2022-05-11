using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GameFramework.Combo;
using GameFramework.Core;
using GameFramework.Input;
using UniRx;
using UnityEngine;

namespace Game.Scripts.MusicGame
{
    public class MusicGame
    {
        /// <summary>
        /// ランク変更イベント.
        /// </summary>
        public IReactiveProperty<JudgeRank> Rank => rankProperty;
        private ReactiveProperty<JudgeRank> rankProperty = new();
        /// <summary>
        /// コンボ変更イベント.
        /// </summary>
        public IReactiveProperty<int> ComboCount => combo.Count;
        public bool CanComboDraw() => combo.CanDraw();

        private CompositeDisposable compositeDisposable = new();
        private GameContext gameContext;
        private Combo combo = new();
        
        /// <summary>
        /// ゲーム開始時間.
        /// </summary>
        private float playStartTime;

        /// <summary>
        /// 叩くノーツ.
        /// </summary>
        private Dictionary<Note, NoteView> noteToViewMap = new();
        private List<Note> notes = new();

        public MusicGame(GameContext context, NoteViewMaker noteViewMaker, NotePointSettings notePointSettings)
        {
            gameContext = context;
            
            // 入力.
            context.InputEventProvider.OnPushedDecide.Subscribe(_ => PushDecideKey()).AddTo(compositeDisposable);
            context.InputEventProvider.OnPushedLeft.Subscribe(_ => PushDecideKey()).AddTo(compositeDisposable);
            context.InputEventProvider.OnPushedRight.Subscribe(_ => PushDecideKey()).AddTo(compositeDisposable);
            
            // ノーツデータを生成.
            // ノーツビューを生成.
            for (int i = 0; i < 100; ++i)
            {
                var noteView = noteViewMaker.CreateNote(NoteType.Normal);
                var prevPoint = i % 4;
                var nextPoint = (i + 1) % 4; 
                var note = new Note(i/2 * 2f + 3f, NoteType.Normal, (NotePointType)prevPoint, (NotePointType)nextPoint, noteView);
                notes.Add(note);
                noteToViewMap.Add(note, noteView);
                
                gameContext.PlayingTime.Subscribe(time =>
                {
                    var nextPosition = notePointSettings.GetPosition(note.NextPoint);
                    var prevPosition = notePointSettings.GetPosition(note.PrevPoint);
                    var subPosition = prevPosition - nextPosition;
                    var subTime = note.Time - time;
                    var pos = nextPosition + subPosition * subTime;
                    noteView.transform.localPosition = new Vector3(pos.x, pos.y, 0f);

                    // 判定時間を過ぎた
                    //if (note.Active && subTime < -BAD_TIME)
                    if (note.Active && subTime < 0)
                    {
                        note.Active = false;
                        noteToViewMap[note].gameObject.SetActive(false);
                        rankProperty.Value = JudgeRank.Miss;
                        combo.Reset();
                    }
                    
                }).AddTo(compositeDisposable);
            }
        }
        
        ~MusicGame()
        {
            compositeDisposable.Dispose();   
        }

        /// <summary>
        /// ゲーム開始
        /// </summary>
        public void PlayGame()
        {
            gameContext.InGamePlay();
        }
        
        /// <summary>
        /// ノーツを叩く 
        /// </summary>
        private void PushDecideKey()
        {
            var note = notes.FirstOrDefault(x => x.Active);
            if (note == null)
            {
                return;
            }
            
            // 判定時間内か
            var subTime = note.Time - gameContext.PlayingTime.Value;
            if (-GameDefine.BAD_TIME <= subTime && subTime <= GameDefine.BAD_TIME)
            {
                // ランク
                rankProperty.Value = TimingRank.GetRank(subTime);
                
                // コンボ
                combo.Add();
            
                // ノーツ削除
                note.Active = false;
                noteToViewMap[note].gameObject.SetActive(false);
            }
        }
    }
}
