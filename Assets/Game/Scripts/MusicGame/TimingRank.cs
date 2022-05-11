using UnityEngine;

namespace Game.Scripts.MusicGame
{
    public static class TimingRank
    {
        /// <summary>
        /// 判定ランク取得
        /// </summary>
        /// <param name="subTime"></param>
        /// <returns></returns>
        public static JudgeRank GetRank(float subTime)
        {
            if (-GameDefine.PERFECT_TIME <= subTime && subTime <= GameDefine.PERFECT_TIME)
            {
                Debug.Log("JudgeRank:Perfect");
                return JudgeRank.Perfect;
            }
            
            if (-GameDefine.GREAT_TIME <= subTime && subTime <= GameDefine.GREAT_TIME)
            {
                Debug.Log("JudgeRank:Great");
                return JudgeRank.Great;
            }
            
            if (-GameDefine.GOOD_TIME <= subTime && subTime <= GameDefine.GOOD_TIME)
            {
                Debug.Log("JudgeRank:Good");
                return JudgeRank.Good;
            }
            
            if (-GameDefine.BAD_TIME <= subTime && subTime <= GameDefine.BAD_TIME)
            {
                Debug.Log("JudgeRank:Bad");
                return JudgeRank.Bad;
            }

            return JudgeRank.Miss;
        }
    }
}