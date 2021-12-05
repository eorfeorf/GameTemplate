using System;
using Game.Scripts.Notes;
using UnityEngine;

public class TapNote : NoteBase
{
    private float judgeTime;

    private void Awake()
    {
        
    }

    public void Initialize(NoteType type)
    {
        this.type = type;
    }

    public override void Judge(Touch touch)
    {
        throw new System.NotImplementedException();
    }
}
