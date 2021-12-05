using UnityEngine;

namespace Game.Scripts.Notes
{
    public abstract class NoteBase : MonoBehaviour, INoteJudge
    {
        protected NoteType type;

        public abstract void Judge(Touch touch);
    }
}
