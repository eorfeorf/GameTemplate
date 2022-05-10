using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.MusicGame
{
    public enum NotePointType
    {
        U,R,D,L
    }
    
    public class NotePointSettings : MonoBehaviour
    {
        [SerializeField] private Transform[] points;
        
        public Vector3 GetPosition(NotePointType pointType)
        {
            return points[(int)pointType].position;
        }
    }
}
