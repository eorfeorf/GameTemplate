using UnityEngine;

namespace Game.Scripts.Notes
{
    public abstract class NoteBase : INoteJudge
    {
        protected NoteType type;
        protected float judgeTimeSec;

        public NoteBase(NoteType type, float judgeTimeSec)
        {
            this.type = type;
            this.judgeTimeSec = judgeTimeSec;
        }

        public abstract void Judge(Touch touch);
    }
}
