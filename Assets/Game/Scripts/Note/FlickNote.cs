using Game.Scripts.Notes;
using UnityEngine;

namespace Game.Scripts.Note
{
    public class FlickNote : NoteBase
    {
        private float judgeTime;
    
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
