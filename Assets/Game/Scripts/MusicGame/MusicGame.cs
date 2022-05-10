using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GameFramework.Core;
using GameFramework.Input;
using UniRx;
using UnityEngine;

namespace Game.Scripts.MusicGame
{
    public enum JudgeRank
    {
        Perfect,
        Great,
        Good,
        Bad,
        Miss,
    }
    
    public class MusicGame
    {
        public IReactiveProperty<JudgeRank> Rank => rankProperty;
        private ReactiveProperty<JudgeRank> rankProperty = new();

        private CompositeDisposable compositeDisposable = new();
        private GameContext gameContext;

        private const float STANDARD_TIME = 1 / 60f;
        private const float PERFECT_TIME = STANDARD_TIME*4;
        private const float GREAT_TIME = STANDARD_TIME*10;
        private const float GOOD_TIME = STANDARD_TIME*16;
        private const float BAD_TIME = STANDARD_TIME*22;
        
        /// <summary>
        /// ゲーム開始時間
        /// </summary>
        private float playStartTime;

        /// <summary>
        /// 叩くノーツ
        /// </summary>
        private Dictionary<Note, NoteView> noteToViewMap = new();
        private List<Note> notes = new();

        public MusicGame(GameContext context, NoteViewMaker noteViewMaker, NotePointSettings notePointSettings)
        {
            gameContext = context;
            
            // 入力
            context.InputEventProvider.OnPushedDecide.Subscribe(_ => PushDecideKey()).AddTo(compositeDisposable);
            context.InputEventProvider.OnPushedLeft.Subscribe(_ => PushDecideKey()).AddTo(compositeDisposable);
            context.InputEventProvider.OnPushedRight.Subscribe(_ => PushDecideKey()).AddTo(compositeDisposable);
            
            // ノーツデータを生成
            // ノーツビューを生成
            for (int i = 0; i < 1; ++i)
            {
                var noteView = noteViewMaker.CreateNote(NoteType.Normal);
                var prevPoint = i % 4;
                var nextPoint = (i + 1) % 4; 
                var note = new Note(i * 2f + 3f, NoteType.Normal, (NotePointType)prevPoint, (NotePointType)nextPoint, noteView);
                notes.Add(note);
                noteToViewMap.Add(note, noteView);
                
                gameContext.PlayingTime.Subscribe(time =>
                {
                    var nextPosition = notePointSettings.GetPosition(note.NextPoint);
                    var prevPosition = notePointSettings.GetPosition(note.PrevPoint);
                    var subPosition = prevPosition - nextPosition;
                    var subTime = note.Time - time;
                    var pos = nextPosition + subPosition * subTime;
                    noteView.transform.position = new Vector3(pos.x, pos.y, 0f);

                    // 判定時間を過ぎた
                    //if (note.Active && subTime < -BAD_TIME)
                    if (note.Active && subTime < 0)
                    {
                        note.Active = false;
                        noteToViewMap[note].gameObject.SetActive(false);
                        rankProperty.Value = JudgeRank.Miss;
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
            if (-BAD_TIME <= subTime && subTime <= BAD_TIME)
            {
                // ランク
                rankProperty.Value = GetRank(subTime);
            
                // ノーツ削除
                note.Active = false;
                noteToViewMap[note].gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// レーン切り替え
        /// </summary>
        private void PushLeftArrowKey()
        {
            
        }

        /// <summary>
        /// レーン切り替え
        /// </summary>
        private void PushRightArrowKey()
        {
            
        }

        /// <summary>
        /// 時間更新
        /// </summary>
        private void UpdatePlayingTime()
        {
            
        }

        /// <summary>
        /// 判定ランク取得
        /// </summary>
        /// <param name="subTime"></param>
        /// <returns></returns>
        private JudgeRank GetRank(float subTime)
        {
            if (-PERFECT_TIME <= subTime && subTime <= PERFECT_TIME)
            {
                Debug.Log("JudgeRank:Perfect");
                return JudgeRank.Perfect;
            }
            
            if (-GREAT_TIME <= subTime && subTime <= GREAT_TIME)
            {
                Debug.Log("JudgeRank:Great");
                return JudgeRank.Great;
            }
            
            if (-GOOD_TIME <= subTime && subTime <= GOOD_TIME)
            {
                Debug.Log("JudgeRank:Good");
                return JudgeRank.Good;
            }
            
            if (-BAD_TIME <= subTime && subTime <= BAD_TIME)
            {
                Debug.Log("JudgeRank:Bad");
                return JudgeRank.Bad;
            }

            return JudgeRank.Miss;
        }
    }
}
