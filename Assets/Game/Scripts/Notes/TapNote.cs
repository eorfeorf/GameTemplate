using Game.Scripts.Notes;
using UnityEngine;

public class TapNote : NoteBase
{

    public TapNote(NoteType type, float judgeTimeSec) : base(type, judgeTimeSec)
    {
    }
    
    public override void Judge(Touch touch)
    {
        throw new System.NotImplementedException();
    }
}
