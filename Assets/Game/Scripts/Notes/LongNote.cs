using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Notes;
using UnityEngine;

public class LongNote : NoteBase
{

    public LongNote(NoteType type, float judgeTimeSec) : base(type, judgeTimeSec)
    {
    }
    
    public override void Judge(Touch touch)
    {
        throw new System.NotImplementedException();
    }
}
