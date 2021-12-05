using Game.Scripts.Notes;
using UnityEngine;

namespace Game.Scripts.Note
{
    public class LongNote : NoteBase
    {

        public void Initialize(NoteType type)
        {
            this.type = type;
        }
    
        public override void Judge(Touch touch)
        {
            throw new System.NotImplementedException();
        }
    }
}
