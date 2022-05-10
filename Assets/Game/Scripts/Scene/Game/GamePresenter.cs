using Game.Scripts.Core;
using Game.Scripts.MusicGame;
using GameFramework.Scene;
using UniRx;
using UnityEngine;

namespace Game.Scripts.Scene.Game
{
    public class GamePresenter : ScenePresenterBase<GameModel>
    {
        [SerializeField] private GameObject noteViewParent;
        [SerializeField] private JudgeRankView judgeRankView;
        [SerializeField] private NotePointSettings notePointSettings;
        
        private NoteViewMaker noteViewMaker;
        private MusicGame.MusicGame musicGame;

#if UNITY_EDITOR
        private void Awake()
        {
            if (gameSceneManager != null) return;
            var gameManager = GameObject.Find("GameManager")?.GetComponent<GameManager>();
            if (gameManager == null) return;
            
            gameSceneManager = gameManager.GameSceneManager;
            gameContext = gameManager.GameContext;

            Debug.Log("Scene:Create GamePresenter !!!");
        }
#endif
        
        private void Start()
        {
            noteViewMaker = GetComponent<NoteViewMaker>();
            noteViewMaker.SetParent(noteViewParent.transform);
            
            musicGame = new MusicGame.MusicGame(gameContext, noteViewMaker, notePointSettings);

            musicGame.Rank.SkipLatestValueOnSubscribe().Subscribe(rank =>
            {
                judgeRankView.judgeRank.Value = rank;
            }).AddTo(this); 
        }
    }
}
