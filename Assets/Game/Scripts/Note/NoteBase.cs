using Game.Scripts.Notes;
using UnityEngine;

namespace Game.Scripts.Note
{
    public abstract class NoteBase : MonoBehaviour, INoteJudge
    {
        protected NoteType type;
        protected Rect touchRange;

        public abstract void Initialize(GameContext.GameContext gameContext, NoteType noteType, float[] judgeTimes);

        public abstract void Judge(Touch touch, float time);
    }
}
