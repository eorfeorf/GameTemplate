using TMPro;
using UniRx;
using UnityEngine;

namespace Game.Scripts.MusicGame
{
    public class JudgeRankView : MonoBehaviour
    {
        [SerializeField] private TextMeshPro judgeRankText;

        [HideInInspector]
        public ReactiveProperty<JudgeRank> judgeRank = new();

        private static readonly string[] RankTexts = new string[] {
            GameText.JUDGE_RANK_PERFECT,
            GameText.JUDGE_RANK_GREAT,
            GameText.JUDGE_RANK_GOOD,
            GameText.JUDGE_RANK_BAD,
            GameText.JUDGE_RANK_MISS,
        };

        private void Start()
        {
            judgeRank.SkipLatestValueOnSubscribe().Subscribe(rank =>
            {
                judgeRankText.text = RankTexts[(int) rank];
            }).AddTo(this);
        }
    }
}