using Game.Scripts.GameManager;
using UnityEngine;

namespace Game.Scripts.Notes
{
    public abstract class NoteBase : MonoBehaviour, INoteJudge
    {
        protected NoteType type;

        public abstract void Initialize(GameContext gameContext, NoteType noteType, float[] judgeTimes);

        public abstract void Judge(Touch touch, float time);
    }
}
